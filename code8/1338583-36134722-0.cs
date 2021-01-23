    public Posts Get(int id)
        {
            var builder = Builders<Posts>.Filter;
            var query = builder.Eq(x => x.postid, id);
            return collection.Find(query).SingleOrDefaultAsync().Result;
        }
