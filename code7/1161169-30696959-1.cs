    public string GetKeyName<TEntity>(myappContext dbContext, TEntity entity) where TEntity : class
            {
                ObjectContext objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                ObjectSet<TEntity> set = objectContext.CreateObjectSet<TEntity>();
                return set.EntitySet.ElementType.KeyMembers.FirstOrDefault().Name;
            }
    
            public Expression<Func<TEntity, bool>> GetCompareExpression<TEntity>(string keyName, object value) where TEntity : class
            {
                var parameter = Expression.Parameter(typeof(TEntity), "x");
                var property = Expression.Property(parameter, keyName);
                var method = property.Type.GetMethod("Equals", new[] { property.Type });
                var convertedValue = Convert.ChangeType(value, property.Type);
                var expression = Expression.Call(property, method, Expression.Constant(convertedValue));
    
                return Expression.Lambda<Func<TEntity, bool>>(expression, parameter);
            }
