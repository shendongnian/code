    public static IQueryable<TEntity> IncludeMultiple<TEntity, TProperty>(
    			this IQueryable<TEntity> source,
    			List<Expression<Func<TEntity, TProperty>>> navigationPropertyPath) where TEntity : class
    		{
    			foreach (var navExpression in navigationPropertyPath)
    			{
    				source= source.Include(navExpression);
    			}
    			return source.AsQueryable();
    		}
