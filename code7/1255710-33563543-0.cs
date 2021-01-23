	void Main()
	{
		var a = "I hope to do something good from this chance.I think my Test form will help me in ODI.Scoring runs in international cricket, regardless of the format, gives a player confidence.";
	
		var b = "I hope to do something good this chance. I think my Testing form will help me in ODI Format. Scoring runs in latest international cricket, regardless of the format, gives a playing confidence.";
		
		var d = new Difference(a,b);
		
		Console.WriteLine("Number of differences: {0}", d.Count);
	
		foreach (var diff in d.Differences)
		{
			Console.WriteLine("Different: {0}", diff);
		}
	}
	
	class Difference
	{
		string a;
		string b;
		
		List<string> notInA;
		List<string> notInB;
	
		public int Count
		{
			get { return notInA.Count + notInB.Count; }
		}
	
		public IEnumerable<string> Differences
		{
			get { return notInA.Concat(notInB); }
		}
		
		public Difference(string a, string b)
		{
			this.a = a;
			this.b = b;
	
			var itemsA = Split(a);
			var itemsB = Split(b);
			
			var changedPairs =
				from x in itemsA
				from y in itemsB
				where (x.StartsWith(y) || y.StartsWith(x)) && y != x
				select new { x, y };
			
			var softChanged = changedPairs.SelectMany(p => new[] {p.x, p.y}).Distinct().ToList();
			
			notInA = itemsA.Except(itemsB).Except(softChanged).ToList();
			notInB = itemsB.Except(itemsA).Except(softChanged).ToList();
		}
	
		IEnumerable<string> Split(string x)
		{
			return x.Split(new[] { " ", ".", ","}, StringSplitOptions.RemoveEmptyEntries);
		}
	}
	
