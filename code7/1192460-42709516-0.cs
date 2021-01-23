    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.ManagedDataAccess.Client;
    
    namespace SampleOracle
    {
        class Program
        {
            static void Main(string[] args)
            {
                OracleConnection connection = new OracleConnection();
                connection.ConnectionString = "User Id=<username>;Password=<password>;Data Source=<data source>"; //Data Source Format -> //IP_HOST:PORT/SERVICE_NAME e.g. //127.0.0.1:1521/Service_Name
                connection.Open();
                Console.WriteLine("Connected to Oracle" + connection.ServerVersion);           
            }
        }
    }
