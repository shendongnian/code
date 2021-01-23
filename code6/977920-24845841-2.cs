	public Expression<Func<int, string, KV>> InitKV()
	{
		var pK = Expression.Parameter(typeof(int), "k");
		var pV = Expression.Parameter(typeof(string), "v");
	
		Type tKV = typeof(KV);
		MemberInfo miKey = tKV.GetMember("Key")[0];
		MemberInfo miValue = tKV.GetMember("Value")[0];
	
		Expression meminit = 
			Expression.MemberInit(
				Expression.New(tKV),
				Expression.Bind(miKey, pK),
				Expression.Bind(miValue, pV)
			);
		
		return (Expression<Func<int, string, KV>>)Expression.Lambda(meminit, pK, pV);		
	}
