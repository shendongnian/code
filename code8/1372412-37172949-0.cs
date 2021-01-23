    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Orient.Client;
    namespace OrientTestCreateDB
    {
        class CreateDB
        {
        private static string _hostname = "127.0.0.1";
        private static int _port = 2424;
        private static string _rootUserName = "root";
        private static string _rootUserParssword = "root";
        private static OServer _server;
        private static string _DBname = "TestDatabaseName";
        private static string _username = "admin";
        private static string _password = "admin";
        static void Main(string[] args)
        {
            _server = new OServer(_hostname, _port, _rootUserName, _rootUserParssword);
            
            //If the DB already exists I delete it
            if (_server.DatabaseExist(_DBname, OStorageType.PLocal))
            {
                _server.DropDatabase("TestDatabaseName", OStorageType.PLocal);
                Console.WriteLine("Database " + _DBname + " deleted");
            }
            //Creating the new DB
            _server.CreateDatabase(_DBname, ODatabaseType.Graph, OStorageType.PLocal);
            Console.WriteLine("Database " + _DBname + " created");
            //Connect to the DB and populate it
            OClient.CreateDatabasePool(
            "127.0.0.1",
            2424,
            _DBname,
            ODatabaseType.Graph,
            _username,
            _password,
            10,
            "myTestDatabaseAlias"
            );
            Console.WriteLine("Connected to the DB " + _DBname);
            using (ODatabase database = new ODatabase("myTestDatabaseAlias"))
                {
                    database
                         .Create.Class("TestClass")
                         .Extends<OVertex>()
                         .Run();
                    OVertex createdVertex = database
                         .Create.Vertex("TestClass")
                         .Set("name", "LucaS")
                         .Run();
                    Console.WriteLine("Created vertex with @rid " + createdVertex.ORID);
               }
           }
        }
    }
