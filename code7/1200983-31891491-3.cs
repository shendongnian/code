	public static void Main()
	{
		string input = "9 English";
		var searchInput = CreateSearchInput(input);
		string sqlQuery = ConstructSearchQuery(searchInput);
		Console.WriteLine("Search: Number[{0}] TitleOrBoard[{1}]", searchInput.Number, searchInput.TitleOrBoard);
		Console.WriteLine("SQL Query: {0}", sqlQuery);
	}
