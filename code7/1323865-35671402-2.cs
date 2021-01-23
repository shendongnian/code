    string cmdText = @"SELECT e.*, i.*
                       FROM Entity e INNER JOIN Identifier i ON i.EntityId = e.Id";
    var lookup = new Dictionary<int, Entity>();
    using (IDbConnection connection = OpenConnection())
    {
        var multi = connection.Query<Entity, EntityIdentifier, Entity>(cmdText, 
                                    (entity, identifier) =>
        {
            Entity current;
            if (!lookup.TryGetValue(entity.ID, out current))
            {
                lookup.Add(entity.ID, current = entity);
                current.Identifiers = new List<EntityIdentifier>();
            }
            current.Identifiers.Add(identifier);
            return current;
        }, splitOn: "i.ID").Distinct();
        return multi;
    }
