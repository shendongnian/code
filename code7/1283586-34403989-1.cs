    List<SelectItemViewModel<TId>> GetAvailableItems<TEntity, TId>(IQueryable<TEntity> source, Expression<Func<TEntity, string>> nameSelector)
        where TEntity : class, IEntity<TId>
    {
        var item = nameSelector.Parameters[0];
        var targetType = typeof(SelectItemViewModel<TId>);
        var selector = Expression.Lambda<Func<TEntity, SelectItemViewModel<TId>>>( 
            Expression.MemberInit(Expression.New(targetType),
                Expression.Bind(targetType.GetProperty("Name"), nameSelector.Body),
                Expression.Bind(targetType.GetProperty("Id"), Expression.Property(item, "Id"))
            ), item);
        return source.Select(selector).ToList();
    }
