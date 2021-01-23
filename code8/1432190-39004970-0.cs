	public static string DecimalFormatCludge(string original)
	{
		var split = original.Split('.');
		return string.Join(".", (new [] { int.Parse(split[0]).ToString("#,##0")}).Concat(split.Skip(1)));
	}
