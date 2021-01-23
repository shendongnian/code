	public static string ConstructSearchQuery(SearchInput searchInput)
	{
		StringBuilder sb = new StringBuilder("SELECT * FROM Books WHERE");
		sb.AppendFormat(" ([Title] LIKE '%{0}%' OR [Board] LIKE '%{0}%')", searchInput.TitleOrBoard);
		if (!String.IsNullOrWhiteSpace(searchInput.Number))
		{
			sb.AppendFormat(" OR Class = '%{0}%'", searchInput.Number);
		}
		return sb.ToString();
	}
