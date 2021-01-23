    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace CS_Stats_Console_GetValue
    {
      class Program
      {
        static void Main(string[] args)
        {
          string connectionString = GetConnectionString();
    
          using (SqlConnection awConnection = 
            new SqlConnection(connectionString))
          {
            // StatisticsEnabled is False by default.
            // It must be set to True to start the 
            // statistic collection process.
            awConnection.StatisticsEnabled = true;
    
            string productSQL = "SELECT * FROM Production.Product";
            SqlDataAdapter productAdapter = 
              new SqlDataAdapter(productSQL, awConnection);
    
            DataSet awDataSet = new DataSet();
    
            awConnection.Open();
    
            productAdapter.Fill(awDataSet, "ProductTable");
            // Retrieve the current statistics as
            // a collection of values at this point
            // and time.
            IDictionary currentStatistics =
              awConnection.RetrieveStatistics();
    
            Console.WriteLine("Total Counters: " +
              currentStatistics.Count.ToString());
            Console.WriteLine();
    
            // Retrieve a few individual values
            // related to the previous command.
            long bytesReceived =
                (long) currentStatistics["BytesReceived"];
            long bytesSent =
                (long) currentStatistics["BytesSent"];
            long selectCount =
                (long) currentStatistics["SelectCount"];
            long selectRows =
                (long) currentStatistics["SelectRows"];
    
            Console.WriteLine("BytesReceived: " +
                bytesReceived.ToString());
            Console.WriteLine("BytesSent: " +
                bytesSent.ToString());
            Console.WriteLine("SelectCount: " +
                selectCount.ToString());
            Console.WriteLine("SelectRows: " +
                selectRows.ToString());
    
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
          }
    
        }
        private static string GetConnectionString()
        {
          // To avoid storing the connection string in your code,
          // you can retrive it from a configuration file.
          return "Data Source=localhost;Integrated Security=SSPI;" + 
            "Initial Catalog=AdventureWorks";
        }
      }
    }
