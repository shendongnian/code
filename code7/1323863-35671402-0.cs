    string cmdText = @"SELECT t.*, i.*
                       FROM [Platform].[Transaction] t
                       INNER JOIN [Platform].[TransactionIdentifier] i 
                             ON i.EntityId = t.Id
                       WHERE t.PortfolioId = @id";
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
        }, splitOn: "ID").Distinct();
        return multi;
    }
