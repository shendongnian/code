    var resultList = new StringCollection();
    var myRegex = new Regex("{[^}]*}", RegexOptions.Multiline);
    Match matchResult = myRegex.Match(yourString);
    while (matchResult.Success) {
    	resultList.Add(matchResult.Value);
    	Console.WriteLine(matchResult.Value);
    	matchResult = matchResult.NextMatch();
    	} 
