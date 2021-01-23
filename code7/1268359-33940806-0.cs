    var con = new   MongoConnectionStringBuilder(ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString);     
            
        var server = MongoServer.Create(con);
        var db = server.GetDatabase(con.DatabaseName);
        var collection = db.GetCollection<Post>("post");
