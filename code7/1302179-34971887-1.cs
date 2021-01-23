    public static IEnumerable<T> MapReader<T>(this DbContext context, DbDataReader reader) where T : class
    {
    	var list = new List<T>();
    
    	// CREATE a new query to steal the shaper factory from it
    	var query = ((IObjectContextAdapter)context).ObjectContext.CreateObjectSet<T>();
    
    	// REFLECTION: Query.QueryState
    	var queryStateProperty = query.GetType().GetProperty("QueryState", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    	var queryState = queryStateProperty.GetValue(query, null);
    
    	// REFLECTION: Query.QueryState.GetExecutionPlan(null)
    	var getExecutionPlanMethod = queryState.GetType().GetMethod("GetExecutionPlan", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    	var getExecutionPlan = getExecutionPlanMethod.Invoke(queryState, new object[] { null });
    
    	// REFLECTION: Query.QueryState.GetExecutionPlan(null).ResultShaperFactory
    	var resultShaperFactoryField = getExecutionPlan.GetType().GetField("ResultShaperFactory", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    	if (resultShaperFactoryField == null)
    	{
    		throw new Exception("Oops!A general error has occurred.Please report the issue including the stack trace to our support team: info@zzzprojects.com");
    	}
    	var resultShaperFactory = resultShaperFactoryField.GetValue(getExecutionPlan);
    
    	// REFLECTION: Query.QueryState.GetExecutionPlan(null).ResultShaperFactory.Create(parameters)
    	var createMethod = resultShaperFactory.GetType().GetMethod("Create", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    
    	// EF5: var create = createMethod.Invoke(resultShaperFactory, new object[] {reader, Query.Context, Query.Context.MetadataWorkspace, MergeOption.AppendOnly, false});
    
    	var create = createMethod.Invoke(resultShaperFactory, new object[] { reader, query.Context, query.Context.MetadataWorkspace, MergeOption.AppendOnly, false, true });
    
    	// REFLECTION: Query.QueryState.GetExecutionPlan(null).ResultShaperFactory.Create(parameters).GetEnumerator()
    	var getEnumeratorMethod = create.GetType().GetMethod("GetEnumerator", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    	var getEnumerator = getEnumeratorMethod.Invoke(create, new object[0]);
    
    	var enumerator = (IEnumerator<T>)getEnumerator;
    
    	while (enumerator.MoveNext())
    	{
    		list.Add(enumerator.Current);
    	}
    	return list;
    }
