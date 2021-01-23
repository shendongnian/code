	public List<Person> SearchPeople(string searchTerm, Expression<Func<Person, string>> personProperty)
	{
		// Note: Explanatory comments below assume that the "personProperty" lambda expression is:
		//       p => p.FirstName
		// Get MethodInfo for "string.Contains(string)" method.
		var stringContainsMethod = typeof(string).GetMethod(
			nameof(string.Contains),
			new Type[] { typeof(string) });
		// Create a closure class around searchTerm.
		// Using this technique allows EF to use parameter binding
		// when building the SQL query.
		// In contrast, simply using "Expression.Constant(searchTerm)",
		// makes EF hard-code the string in the SQL, which is not usually desirable.
		var closure = new { SearchTerm = searchTerm };
		var searchTermProperty = Expression.Property(
			Expression.Constant(closure), // closure
			nameof(closure.SearchTerm));  // SearchTerm
		// This forms the complete statement: p.FirstName.Contains(closure.SearchTerm)
		var completeStatement = Expression.Call(
			personProperty.Body,  // p.FirstName
			stringContainsMethod, // .Contains()
			searchTermProperty);  // closure.SearchTerm
		// This forms the complete lambda: p => p.FirstName.Contains(closure.SearchTerm)
		var whereClauseLambda = Expression.Lambda<Func<Person, bool>>(
			completeStatement,             // p.FirstName.Contains(closure.SearchTerm)
			personProperty.Parameters[0]); // p
		// Execute query using constructed lambda.
		return myDbContext.Persons.Where(whereClauseLambda).ToList();
	}
