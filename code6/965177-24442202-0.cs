	static Expression<Func<T, bool>> CreateContainsPredicate<T>(Expression<Func<T, string>> property, string value)
	{
		return Expression.Lambda<Func<T, bool>>( // Where() wants this kind of expression
			Expression.Call(                     // we need to call method
				property.Body,                   // on instance returned by passed expression
				typeof(string).GetMethod("Contains", new [] { typeof(string) }), // call 'Contains()'
				Expression.Constant(value)),     // pass value to Contains() method
			property.Parameters);                // resulting expression has same parameters as input expression
	}
