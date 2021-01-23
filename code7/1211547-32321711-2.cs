    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace YourNamespace
    {
    	internal static class DbHelpers
    	{
    		public static object GetColumnById(this object dbContext, string tableName, string columnName, object id)
    		{
    			var table = (IQueryable)dbContext.GetType().GetProperty(tableName).GetValue(dbContext, null);
    			var row = Expression.Parameter(table.ElementType, "row");
    			var filter = Expression.Lambda(Expression.Equal(Expression.Property(row, "Id"), Expression.Constant(id)), row);
    			var column = Expression.Property(row, columnName);
    			var selector = Expression.Lambda(column, row);
    			var query = Call(Where.MakeGenericMethod(row.Type), table, filter);
    			query = Call(Select.MakeGenericMethod(row.Type, column.Type), query, selector);
    			var value = Call(FirstOrDefault.MakeGenericMethod(column.Type), query);
    			return value;
    		}
    		private static readonly MethodInfo Select = GetGenericMethodDefinition<
    			Func<IQueryable<object>, Expression<Func<object, object>>, IQueryable<object>>>((source, selector) =>
    			Queryable.Select(source, selector));
    		private static readonly MethodInfo Where = GetGenericMethodDefinition<
    			Func<IQueryable<object>, Expression<Func<object, bool>>, object>>((source, predicate) =>
    			Queryable.Where(source, predicate));
    		private static readonly MethodInfo FirstOrDefault = GetGenericMethodDefinition<
    			Func<IQueryable<object>, object>>(source =>
    			Queryable.FirstOrDefault(source));
    		private static MethodInfo GetGenericMethodDefinition<TDelegate>(Expression<TDelegate> e)
    		{
    			return ((MethodCallExpression)e.Body).Method.GetGenericMethodDefinition();
    		}
    		private static object Call(MethodInfo method, params object[] parameters)
    		{
    			return method.Invoke(null, parameters);
    		}
    	}
    }
