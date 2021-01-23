    List<SelectItemViewModel<TId>> GetAvailableItems<TEntity, TId>(IQueryable<TEntity> source, Expression<Func<TEntity, string>> nameSelector)
        where TEntity : class, IEntity<TId>
    {
        var item = nameSelector.Parameters[0];
        var targetType = typeof(SelectItemViewModel<TId>);
        var selector = Expression.MemberInit(
            Expression.New(targetType),
            Expression.Bind(targetType.GetProperty("Name"), nameSelector.Body),
            Expression.Bind(targetType.GetProperty("Id"), Expression.Property(item, "Id"))
        );
        var body = Expression.Call(typeof(Queryable), "Select",
            new Type[] { item.Type, targetType },
            source.Expression, Expression.Quote(Expression.Lambda(selector, item)));
        var query = source.Provider.CreateQuery<SelectItemViewModel<TId>>(body);
        var result = query.ToList();
        return result;
    }
