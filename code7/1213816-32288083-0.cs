    var client = new MongoClient();
    var db = client.GetDatabase("test");
    var col = db.GetCollection<BigClass>("big");
    await db.DropCollectionAsync(col.CollectionNamespace.CollectionName);
    await col.Indexes.CreateOneAsync(Builders<BigClass>.IndexKeys.Text(x => x.Title));
    await col.InsertManyAsync(new[]
    {
        new BigClass { Title = "One Jumped Over The Moon" },
        new BigClass { Title = "Two went Jumping Over The Sun" }
    });
    var filter = Builders<BigClass>.Filter.Text("Jump Over");
    // don't need to Include(x => x.TextMatchScore) because it's already been included with MetaTextScore.
    var projection = Builders<BigClass>.Projection.MetaTextScore("TextMatchScore").Include(x => x._id).Include(x => x.Title);
    var sort = Builders<BigClass>.Sort.MetaTextScore("TextMatchScore");
    var result = await col.Find(filter).Project<SmallClass>(projection).Sort(sort).ToListAsync();
