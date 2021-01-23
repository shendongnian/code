    ProjectionDefinition<BsonDocument> project = null;
    foreach (string columnName in columnsToInclude)
    {
        if (project == null)
        {
            project = Builders<BsonDocument>.Projection.Include(columnName);
        }
        else
        {
            project = project.Include(columnName);
        }
    }
