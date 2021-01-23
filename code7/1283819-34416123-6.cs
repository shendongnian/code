    var p = Expression.Parameter(typeof(int), "i");
	var r = Expression
		.Invoke(f3, new[] { 
			Expression.Invoke(f1, p), 
			Expression.Invoke(f2, p) })	
        .InlineInvokes();
    Expression<Func<int, int>> lam = Expression.Lambda<Func<int, int>>(r, p);
