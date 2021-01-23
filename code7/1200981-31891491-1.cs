	public static SearchInput CreateSearchInput(string input)
	{
		var inputSplitted = input.Trim().Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		int number;
	
		string searchText = "";
		if (int.TryParse(inputSplitted.First(), out number))
		{
			searchText = String.Join(" ", inputSplitted.Skip(1));
		}
		
		var searchInput = new SearchInput()
		{
			Number = number.ToString(),
			TitleOrBoard = searchText
		};
		
		return searchInput;
	}
