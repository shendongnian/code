    var query = context.Set<Log>().AsQueryable();
    var sortInfo = sortOrder.ToString();
    bool descending = sortInfo.EndsWith("Desc");
    var propertyName = sortInfo.Substring(0, sortInfo.Length - (descending ? "Desc" : "Asc").Length);
    var parameter = Expression.Parameter(typeof(Log), "log");
    var selector = Expression.Lambda(Expression.PropertyOrField(parameter, propertyName), parameter);
    query = query.Provider.CreateQuery<Log>(Expression.Call(
    	typeof(Queryable), 
    	"OrderBy" + (descending ? "Descending" : null), 
    	new [] { parameter.Type, selector.Body.Type},
    	query.Expression, Expression.Quote(selector)));
    // ...
