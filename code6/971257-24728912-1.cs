    MongoServer server = MongoServer.Create("mongodb://localhost");  //Creating your server
    server.Connect(); //Connect your server
    MongoDatabase db = server.GetDatabase("Company"); //Connect your database
    using (server.RequestStart(db))
    {
                for ( a = 0; a < 1; a++)
                {
                    for (int i = 0; i < 5000; i++)
                    {
                        var col = db.GetCollection("Workers"); //This is your Collection
                        col.Insert(new BsonDocument { { "Values", "123456" } }); //You need to use your values here
                    }
                 }
    }    
