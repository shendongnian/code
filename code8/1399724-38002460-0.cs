    using System;
    using Orient.Client;
    namespace Stack37995408
    {
        static class Stack37995408
        {
		    private static string _hostname = "127.0.0.1";
            private static int _port = 2424;
            private static string _rootUserName = "root";
            private static string _rootUserPassword = "root";
            private static OServer _server;
            private static string _DBname = "TestDatabaseName";
            private static string _username = "root";
            private static string _password = "root";
		    private static string _aliasDB = "myTestDatabaseAlias";
		    static void Main(string[] args)
		    {
			    _server = new OServer(_hostname, _port, _rootUserName, _rootUserPassword);
			    if (!_server.DatabaseExist(_DBname, OStorageType.PLocal))
			    {
				    _server.CreateDatabase(_DBname, ODatabaseType.Graph, OStorageType.PLocal);
				    Console.WriteLine("Database " + _DBname + " created");
				    //Connect to the DB
				    OClient.CreateDatabasePool(
					    _hostname,
					    _port,
					    _DBname,
					    ODatabaseType.Graph,
					    _username,
					    _password,
					    10,
					    _aliasDB
				    );
				    Console.WriteLine("Connected to the DB " + _DBname);
				    using (ODatabase database = new ODatabase(_aliasDB))
				    {
					    //Classes and properties creation
					    database
					    	.Create
					    	.Class("Users")
					    	.Extends<OVertex>()
					    	.Run();
					    database
					    	.Create
						    .Property("userID", OType.Integer)
						    .Class("users")
						    .Run();
					    //Populate the DB
					    OVertex vertexUser = new OVertex();
					    vertexUser.OClassName = "Users";
					    vertexUser
					    	.SetField("userID", 1);
					    OVertex createVertexUser = database
						    .Create.Vertex(vertexUser)
						    .Run();
					    Console.WriteLine("Created vertex " + createVertexUser.OClassName + " with @rid " + createVertexUser.ORID + " and userID " + createVertexUser.GetField<int>("userID"));
				    }
			    }
			    else
			    {
			    	//Connection
				    OClient.CreateDatabasePool(
				    	_hostname,
				    	_port,
				    	_DBname,
				    	ODatabaseType.Graph,
				    	_username,
				    	_password,
					    10,
				    	_aliasDB
				    );
				    Console.WriteLine("Connected to the DB " + _DBname);
				    using (ODatabase database = new ODatabase(_aliasDB))
				    {
				    	database
					    	.Update()
					    	.Class("Users")
					    	.Set("userID", 2)
					    	.Upsert()
					    	.Where("userID")
					    	.Equals(2)
					    	.Run();
					    Console.WriteLine("Operation executed");
				    }
			    }
            }
        }
    }
