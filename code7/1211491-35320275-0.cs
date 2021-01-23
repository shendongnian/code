    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            var connectionString = ;
	    	var databaseName = ;
	    	var client = new MongoClient("MongoDatabaseURL");
        	container.Register(client);
	    	var database = client.GetDatabase("MongoDatabaseName");
	    	container.Register(database);
            var collection = database.GetCollection<ICollection>("collection");
            container.Register(collection);
        }
    }
