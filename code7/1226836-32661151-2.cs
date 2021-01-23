	static void Main(string[] args)
	{
		string s = string.Empty;
		IDictionary<string, object> dynamicArrays = new ExpandoObject();
		Console.WriteLine("Keep entering words/sentences. Enter blank/empty line to end.");
		s = Console.ReadLine();
		while (!string.IsNullOrEmpty(s))
		{
			string[] words = s.Split(' '); //hello, world
			foreach (var word in words)
			{
				dynamicArrays[word] = word.Select(c => new String(new char[] { c })).ToArray();
			}
			Console.WriteLine("Enter next sentence : ");
			s = Console.ReadLine();
		}
		// do something with dynamicArrays
		return;
	}
