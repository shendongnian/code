    public IQueryable<TEntity> GetAll()
    {
    	var conditionVisitor = new InjectConditionVisitor<TEntity>("Versions", db.Set<TEntity>.Provider, x => x.Where(y => !y.IsDeleted));
    	return db.Set<TEntity>().Where(e => !e.IsDeleted).InterceptWith(conditionVisitor);
    }
    
    var project = await ProjectStore.GetAll().Include(p => p.Versions).SingleOrDefaultAsync(p => p.Id == projectId);
    
    internal class InjectConditionVisitor<T> : ExpressionVisitor
    {
    	private readonly string NavigationString;
    	private readonly IQueryProvider Provider;
    	private readonly Func<IQueryable<T>, IQueryable<T>> QueryCondition;
    
    	public InjectConditionVisitor(string navigationString, IQueryProvider provder , Func<IQueryable<T>, IQueryable<T>> queryCondition)
    	{
    		NavigationString = navigationString;
    		Provider = provder;
    		QueryCondition = queryCondition;
    	}
    
    	protected override Expression VisitMethodCall(MethodCallExpression node)
    	{
    		Expression expression = node;
    
    		bool isIncludeSpanValid = false;
    
    		if (node.Method.Name == "IncludeSpan")
    		{
    			var spanValue = (node.Arguments[0] as ConstantExpression).Value;
    
    			// The System.Data.Entity.Core.Objects.Span class and SpanList is internal, let play with reflection!
    			var spanListProperty = spanValue.GetType().GetProperty("SpanList", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    			var spanList = (IEnumerable)spanListProperty.GetValue(spanValue);
    
    			foreach (var span in spanList)
    			{
    				var spanNavigationsField = span.GetType().GetField("Navigations", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    				var spanNavigation = (List<string>)spanNavigationsField.GetValue(span);
    
    				if (spanNavigation.Contains(NavigationString))
    				{
    					isIncludeSpanValid = true;
    					break;
    				}
    			}
    		}
    
    		if ((node.Method.Name == "Include" && (node.Arguments[0] as ConstantExpression).Value.ToString() == NavigationString)
    			|| isIncludeSpanValid)
    		{
    
    			// CREATE a query from current expression
    			var query = Provider.CreateQuery<T>(expression);
    
    			// APPLY the query condition
    			query = QueryCondition(query);
    
    			// CHANGE the query expression
    			expression = query.Expression;
    		}
    		else
    		{
    			expression = base.VisitMethodCall(node);
    		}
    
    		return expression;
    	}
    }
