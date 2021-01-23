    // A List does hold the queries
    List<FilterDefition<BsonDocument>> QueryConditionList = new List<FilterDefition<BsonDocument>>();
    
    void AddQuery(string sType, string sField, string sValue)
    {
        // I can add of course several Queries
        if (sType == "EQ")
            QueryConditionList.Add(Builders<BsonDocument>.Filter.Eq(sField, sValue));
        else if (sType == "GT")
            QueryConditionList.Add(Builders<BsonDocument>.Filter.Gt(sField, sValue));
        else if (sType == "LT")
            QueryConditionList.Add(Builders<BsonDocument>.Filter.Lt(sField, sValue));
    }
    
    Task ExecuteQueryAsync()
    {
        // The And method takes an IEnumerable<FilterDefinition<BsonDocument>>.
        var filter = Builders<BsonDocument>.Filter.And(QueryConditionList);
        var results = await MoCollection.Find(query).ToListAsync();
    }
