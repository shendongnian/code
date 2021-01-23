	var conversion = new Dictionary<string, string> {
		{ @"[00]", "00" }
	};
	var allLines = "Hello[00]\r\nWorld[00]";
	var conversionRegex = new Regex(string.Join("|", conversion.Keys.Select(key => Regex.Escape(key))));
    var textConverted = conversionRegex.Replace(allLines, n => conversion[n.Value]);
	Console.WriteLine(textConverted);
