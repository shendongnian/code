    public Expression<Func<Entity, bool>> GetExpression(options)
    {
        if (isEqOp)
            return (Entity e) => e.Name == options.Value;
        if (isContainsOp)
            return (Entity e) => e.Name.Contains(options.Value);
    }
    {
         IQueryable<SomeEntity> query = Session.Query<SomeEntity>();
         query = query.Where(GetExpression(options))
         ...
    }
