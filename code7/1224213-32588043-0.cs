    public static class DbRowExtension
	{
		public static bool AnyColIsChecked(this DbRow source, string[] colNames)
		{
			return colNames.Any(x => source[x] == "X");
		}
	}
