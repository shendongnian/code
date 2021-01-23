    BostadsUppgifterMongoDbContext context = new BostadsUppgifterMongoDbContext(_configuration.GetConnectionString("DefaultConnection"), _configuration["ConnectionStrings:DefaultConnectionName"]);
    var residenceCollection = context.MongoDatabase.GetCollection<Residence>("Residences");
    residenceCollection.UpdateMany(x =>
        x.City == "Stockholm",
        Builders<Residence>.Update.Set(p => p.Municipality, "Stoholms län"),
        new UpdateOptions { IsUpsert = false }
    );
