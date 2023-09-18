using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Linq;
using System.Data.SqlClient;
using AnalaizerClassLibrary;

namespace YourNamespace.Tests
{
    [TestClass]
    public class AnalyzerTests
    {

        private const string ConnectionString = "Server=HOME-PC;Integrated Security=True;Database=Tests";

        [TestMethod]
        public void TestCreateStackWithOperatorsOnly()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT InputExpression, PolishExpression FROM TestCreateStackWithOperatorsOnly";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string expression = reader.GetString(0);
                        string expected = reader.GetString(1);   

                        // Act
                        ArrayList result = AnalaizerClass.CreateStack(expression);

                        // Assert
                        ArrayList expectedList = new ArrayList(expected.Split(' '));
                        CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                    }
                }
            }
        }


        [TestMethod]
        public void TestCreateStackWithBrackets()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT InputExpression, PolishExpression FROM TestCreateStackWithBrackets";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string expression = reader.GetString(0); 
                        string expected = reader.GetString(1);  

                        // Act
                        ArrayList result = AnalaizerClass.CreateStack(expression);

                        // Assert
                        ArrayList expectedList = new ArrayList(expected.Split(' '));
                        CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateStackWithDifferentOperators()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT InputExpression, PolishExpression FROM TestCreateStackWithDifferentOperators";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string expression = reader.GetString(0); 
                        string expected = reader.GetString(1); 

                        // Act
                        ArrayList result = AnalaizerClass.CreateStack(expression);

                        // Assert
                        ArrayList expectedList = new ArrayList(expected.Split(' '));
                        CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                    }
                }
            }
        }

        [TestMethod]
        public void TestCreateStackWithEmptyExpression()
        {
            // Arrange
            string expression = "";

            // Act
            ArrayList result = AnalaizerClass.CreateStack(expression);

            // Assert
            ArrayList expected = new ArrayList();
            CollectionAssert.AreEqual(expected.ToArray(), result.ToArray(), GetAssertionMessage(expected, result));
        }

        [TestMethod]
        public void TestCreateStackWithComplexExpression()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string selectQuery = "SELECT InputExpression, PolishExpression FROM TestCreateStackWithComplexExpression";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string expression = reader.GetString(0); 
                        string expected = reader.GetString(1);  

                        // Act
                        ArrayList result = AnalaizerClass.CreateStack(expression);

                        // Assert
                        ArrayList expectedList = new ArrayList(expected.Split(' '));
                        CollectionAssert.AreEqual(expectedList.ToArray(), result.ToArray(), GetAssertionMessage(expectedList, result));
                    }
                }
            }
        }

        private string GetAssertionMessage(ArrayList expected, ArrayList actual)
        {
            return $"Expected: [{string.Join(", ", expected.Cast<string>())}], Actual: [{string.Join(", ", actual.Cast<string>())}]";
        }
    }
}