	string address = "TEXT 3 !@#$%^&*()_}|{\":?> REMOVE ALL SYMBOLS 45";
	var sb = new StringBuilder();
	foreach (var c in address)
	{
		if (Char.IsLetterOrDigit(c) || Char.IsWhiteSpace(c))
			sb.Append(c);
	}
	
	var result = sb.ToString();	
