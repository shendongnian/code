    public async Task<List<ObjectId>> GetEntitiesIdsByEmail(IList<string> emails)
    {
         var regexFilter = "(" + string.Join("|", emails) + ")";
         var projection = Builders<Entity>.Projection.Include(x => x.Id);
         var filter = Builders<Entity>.Filter.Regex("Email",
               new BsonRegularExpression(new Regex(regexFilter, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace)));
         var entities = await GetCollection().Find(filter).Project(projection).ToListAsync();
         return entities.Select(x=>x["_id"].AsObjectId).ToList();
    }
