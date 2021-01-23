    static IQueryable<QueryResultItem<SomeEntity>> GetEntities(IDbSet<SomeEntity> entitySet, IDbSet<AuditLog> auditLogSet)
    {
        Expression<Func<SomeEntity, QueryResultItem<SomeEntity>>> entityExpression = entity =>
            new QueryResultItem<SomeEntity>
            {
                Entity = entity,
                Logs = auditLogSet.Where(a => a.TableName == "SomeEntity" && entity.Id == a.EntityId)
            };
        return entitySet.Select(entityExpression);
    }
