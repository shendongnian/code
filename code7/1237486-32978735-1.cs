    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web.Services;
    
    namespace ConsoleApplication19
    {
      public class Program
      {
        public static void Main(String[] args)
        {
          var connectionString = "Data Source=MyWebBasedServer;Initial Catalog=MyDatabase;Persist Security Info=False;User ID=MyLogin;Password=MyPassword;";
          var a = GetEmployeeIDs_Version1(connectionString);
          var b = GetEmployeeIDs_Version2(connectionString);
        }
    
        /* Version 1
    
           Use a "while" loop to fill a WebData list and return it as an array. */
    
        [WebMethod]
        private static WebData[] GetEmployeeIDs_Version1(String connectionString)
        {
          using (var connection = new SqlConnection(connectionString))
          {
            connection.Open();
    
            var commandText = "SELECT ID, SurName from MyTable";
    
            using (var command = new SqlCommand() { Connection = connection, CommandType = CommandType.Text, CommandText = commandText })
            {
              using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
              {
                var result = new List<WebData>();
    
                while (reader.Read())
                  result.Add(new WebData() { ID = Convert.ToInt32(reader["ID"]), Surname = reader["Surname"].ToString() });
    
                return result.ToArray();
              }
            }
          }
        }
    
        /* Version 2
    
           Fill a DataSet with the result set.
    
           Because there's only one SELECT statement, ADO.Net will
           populate a DataTable with that result set and put the
           DataTable in the dataset's Tables collection.
    
           Use LINQ to convert that table into a WebData array. */
    
        [WebMethod]
        private static WebData[] GetEmployeeIDs_Version2(String connectionString)
        {
          using (var connection = new SqlConnection(connectionString))
          {
            connection.Open();
    
            var commandText = "SELECT ID, SurName from MyTable";
    
            using (var command = new SqlCommand() { Connection = connection, CommandType = CommandType.Text, CommandText = commandText })
            {
              using (var adapter = new SqlDataAdapter())
              {
                var dataSet = new DataSet();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
    
                return
                  dataSet
                  // There should only be one table in the dataSet's Table's collection.
                  .Tables[0]
                  .Rows
                  // DataTable isn't LINQ-aware.  An explicit cast is needed
                  // to allow the use of LINQ methods on the DataTable.Rows collection.
                  .Cast<DataRow>()
                  // The rows in a DataTable filled by an SqlDataAdapter
                  // aren't strongly typed.  All of a row's columns are
                  // just plain old System.Object.  Explicit casts are necessary.
                  .Select(row => new WebData() { ID = Convert.ToInt32(row["ID"]), Surname = row["Surname"].ToString() })
                  // Use LINQ to convert the IEnumerable<WebData> returned by
                  // the .Select() method to an WebData[].
                  .ToArray();
              }
            }
          }
        }
      }
    
      public class WebData
      {
        public Int32 ID { get; set; }
        public String Surname { get; set; }
      }
    }
