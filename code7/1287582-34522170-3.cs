	var sSymb = new System.Collections.Specialized.OrderedDictionary
	{
		{ "<=", "le" },
		{ ">=", "ge" },
		{ "!=", "ne" },
		{ "<", "lt" },
		{ ">", "gt" },
		{ "gt=", "geq" }, 
		{ "lt=", "leq" },
		{ "!in", "notin" }, 
		{ "sub", "subset" }, 
		{ "sup", "supset" } 
	};
	
	var sPattern = sSymb.Keys
		.Cast<string>()
		.Aggregate((left, right) => string.Format("{0}|{1}", left, right));
	
	Regex regex = new Regex(sPattern);
	string st = regex.Replace("a<=bcd<e", match => string.Format("\\{0}", sSymb[match.Value]));
	Console.WriteLine(st);
