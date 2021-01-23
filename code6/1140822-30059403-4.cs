	void Main()
	{
		var results = SearchRequests("Fuzzy", "later").ToList();
		results.Dump();
		
		var results2 = SearchRequests("Literal", "Test me now").ToList();
		results2.Dump();
	}
	
	// Define other methods and classes here
	public class Request
	{
		public int Id {get;set;}
		public string SearchTerm {get;set;}
	}
	
	public IQueryable<Request> LoadData()
	{
		var list = new List<Request>();
		list.Add(new Request {Id = 1, SearchTerm = "Test me now"});
		list.Add(new Request {Id = 2, SearchTerm = "Test me later"});
		list.Add(new Request {Id = 3, SearchTerm = "Test me maybe"});
		list.Add(new Request {Id = 4, SearchTerm = "Test me now"});
		list.Add(new Request {Id = 5, SearchTerm = "Test me later or never"});
		list.Add(new Request {Id = 6, SearchTerm = "Test me maybe or today"});
			
		return list.AsQueryable();
	}
	
	public IQueryable<Request> SearchRequests (string searchType, string searchTerm)
	{
		var data = LoadData();
		var predicate = PredicateBuilder.False<Request>();
		//These two are not correct and I need help writing these
		if (searchType == "Fuzzy")
		{
			predicate = predicate.Or(r => r.SearchTerm.Contains(searchTerm));
		}
		if (searchType == "Literal")
		{
			predicate = predicate.Or (r => r.SearchTerm.Equals(searchTerm));
		}
	
		return data.Where(predicate);
	}
	
	public static class PredicateBuilder
	{
		public static Expression<Func<T, bool>> True<T> ()  { return f => true;  }
		public static Expression<Func<T, bool>> False<T> () { return f => false; }
		
		public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
															Expression<Func<T, bool>> expr2)
		{
			var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
			return Expression.Lambda<Func<T, bool>>
				(Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
		}
		
		public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
															Expression<Func<T, bool>> expr2)
		{
			var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
			return Expression.Lambda<Func<T, bool>>
				(Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
		}
	}
