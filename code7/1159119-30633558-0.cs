    var filterDefinitions = new List<FilterDefinition<DocumentEntity>>();
    foreach (var criteria in searchCriterias)
    {
            filterDefinitions
               .AddRange(criteria.Values
               .Select(value => new ExpressionFilterDefinition<DocumentEntity>(doc => doc.Criterias
                   .Any(x => x.Category == criteria.Category && x.Values.Contains(value)))));
    }
    var filter = Builders<DocumentEntity>.Filter.And(filterDefinitions);
    return await GetCollection<DocumentEntity>().Find(filter).ToListAsync();
