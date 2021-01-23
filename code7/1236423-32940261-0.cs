    var filter = Builders<Book>.Filter.Eq(n => n.Author, AuthorId);
    var projection = Builders<Book>.Projection
        .Include(b => b.Title)
        .Include(b => b.Author)
        .Exclude("_id");
    var options = new FindOptions<Book, BsonDocument> { Projection = projection };
    List<string> books = new List<string>();
    using (var cursor = await BooksCollection.FindAsync(filter, options))
    {
        while (await cursor.MoveNextAsync())
        {
            var batch = cursor.Current;
            foreach (BsonDocument b in batch)
                books.Add(b["Title"].AsString);
        }
    }
