	void Main()
	{
		var alpha = new List<string> { "apple", "pear", };
		var beta = new List<string> { "banana", };
		var gamma = new List<string> { "banana", "apple", };
		
		Console.WriteLine(Compute(alpha, beta, gamma));
		Console.WriteLine(ComputeWithSets(alpha, beta, gamma));
		
		alpha = new List<string> { "apple", "pear", };
		beta = new List<string> { "apple", "pear", };
		gamma = new List<string> { "apple", "pear", };
		
		Console.WriteLine(Compute(alpha, beta, gamma));
		Console.WriteLine(ComputeWithSets(alpha, beta, gamma));
		
		alpha = new List<string> { "apple", "pear", "banana", };
		beta = new List<string> { "apple", "pear", "banana", };
		gamma = new List<string> { "apple", "pear", "banana", };
		
		Console.WriteLine(Compute(alpha, beta, gamma));
		Console.WriteLine(ComputeWithSets(alpha, beta, gamma));
	}
	
	bool Compute(List<string> alpha, List<string> beta, List<string> gamma)
	{
		if (alpha.Count == 0) return false;
		if (beta.Count == 0) return false;
		if (gamma.Count == 0) return false;
		
		foreach (var a in alpha)
			foreach (var b in beta)
				if (a != b)
					foreach (var c in gamma)
						if (c != a && c != b)
						{
							Console.Write(string.Format("{0},{1},{2} =>", a, b, c));
							return true;	
						}
		return false;
	}
	
	bool ComputeWithSets(List<string> alpha, List<string> beta, List<string> gamma)
	{
		var abc = alpha.Intersect(beta.Intersect(gamma));
		var abcCardinality = abc.Count();
		
		var count = abcCardinality;
		if (count >= 3) return true;
		
		var ab = alpha.Intersect(beta).Except(abc);
		count += ab.Count();
		if (count >= 3) return true;
		
		var bc = beta.Intersect(gamma).Except(abc);
		count += bc.Count();
		if (count >= 3) return true;
		
		var ac = alpha.Intersect(gamma).Except(abc);
		count += ac.Count();
		if (count >= 3) return true;
		
		var a = alpha.Except(ab).Except(ac).Except(abc);
		count += a.Count();
		if (count >= 3) return true;
		
		var b = beta.Except(ab).Except(bc).Except(abc);
		count += b.Count();
		if (count >= 3) return true;
		
		var c = gamma.Except(ac).Except(bc).Except(abc);
		count += c.Count();
		if (count >= 3) return true;
		
		return false;
	}
