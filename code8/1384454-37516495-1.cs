	public static IEnumerable<int> DblLinear()
	{
		Func<int, int> fxy = x => 2 * x + 1;
		Func<int, int> fxz = x => 3 * x + 1;
	
		var intermediate = new System.Collections.Generic.SortedSet<int>();
		
		Action<int> safeAdd = x =>
		{
			if (!intermediate.Contains(x))
			{
				intermediate.Add(x);
			}
		};
		
		safeAdd(1);
		while (true)
		{
			var x = intermediate.First();
			safeAdd(fxy(x));
			safeAdd(fxz(x));
			intermediate.Remove(x);
			yield return x;
		}
	}
