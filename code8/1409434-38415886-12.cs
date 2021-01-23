    public static class IncludeExtensions
    {
    	private static readonly MethodInfo IncludeMethodInfo = typeof(EntityFrameworkQueryableExtensions).GetTypeInfo()
    		.GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.Include)).Single(mi => mi.GetParameters().Any(pi => pi.Name == "navigationPropertyPath"));
    
    	private static readonly MethodInfo IncludeAfterCollectionMethodInfo = typeof(EntityFrameworkQueryableExtensions).GetTypeInfo()
    		.GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude)).Single(mi => !mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsGenericParameter);
    
    	private static readonly MethodInfo IncludeAfterReferenceMethodInfo = typeof(EntityFrameworkQueryableExtensions).GetTypeInfo()
    		.GetDeclaredMethods(nameof(EntityFrameworkQueryableExtensions.ThenInclude)).Single(mi => mi.GetParameters()[0].ParameterType.GenericTypeArguments[1].IsGenericParameter);
    
    	public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> source, params string[] propertyPaths)
    		where TEntity : class
    	{
    		var entityType = typeof(TEntity);
    		object query = source;
    		foreach (var propertyPath in propertyPaths)
    		{
    			Type prevPropertyType = null;
    			foreach (var propertyName in propertyPath.Split('.'))
    			{
    				Type parameterType;
    				MethodInfo method;
    				if (prevPropertyType == null)
    				{
    					parameterType = entityType;
    					method = IncludeMethodInfo;
    				}
    				else
    				{
    					parameterType = prevPropertyType;
    					method = IncludeAfterReferenceMethodInfo;
    					if (parameterType.IsConstructedGenericType && parameterType.GenericTypeArguments.Length == 1)
    					{
    						var elementType = parameterType.GenericTypeArguments[0];
    						var collectionType = typeof(ICollection<>).MakeGenericType(elementType);
    						if (collectionType.IsAssignableFrom(parameterType))
    						{
    							parameterType = elementType;
    							method = IncludeAfterCollectionMethodInfo;
    						}
    					}
    				}
    				var parameter = Expression.Parameter(parameterType, "e");
    				var property = Expression.PropertyOrField(parameter, propertyName);
    				if (prevPropertyType == null)
    					method = method.MakeGenericMethod(entityType, property.Type);
    				else
    					method = method.MakeGenericMethod(entityType, parameter.Type, property.Type);
    				query = method.Invoke(null, new object[] { query, Expression.Lambda(property, parameter) });
    				prevPropertyType = property.Type;
    			}
    		}
    		return (IQueryable<TEntity>)query;
    	}
    }
