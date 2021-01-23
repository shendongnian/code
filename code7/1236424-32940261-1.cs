    var filter = Builders<Book>.Filter.Eq(n => n.Author, AuthorId);
    // Just project the Title and Author properties of each Book document
    var projection = Builders<Book>.Projection
        .Include(b => b.Title)
        .Include(b => b.Author)
        .Exclude("_id"); // _id is special and needs to be explicitly excluded if not needed
    var options = new FindOptions<Book, BsonDocument> { Projection = projection };
    List<string> books = new List<string>();
    using (var cursor = await BooksCollection.FindAsync(filter, options))
    {
        while (await cursor.MoveNextAsync())
        {
            var batch = cursor.Current;
            foreach (BsonDocument b in batch)
                // Get the string value of the Title field of the BsonDocument
                books.Add(b["Title"].AsString);
        }
    }
