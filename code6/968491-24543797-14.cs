    static IQueryable<QueryResultItem<SomeEntity>> GetEntities(IDbSet<SomeEntity> entitySet, IDbSet<AuditLog> auditLogSet)
    {
        return entitySet.Select(entity =>
            new QueryResultItem<SomeEntity>
            {
                Entity = entity,
                Logs = auditLogSet.Where(a => a.TableName == "SomeEntity" && entity.Id == a.EntityId)
            });
    }
