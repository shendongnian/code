    Regex normalRegex = new Regex(@"&nbsp;\.\.\.&nbsp;.*?>(.*?)<\/a>", RegexOptions.SingleLine);
    Regex secondaryRegex = new Regex(@"page=.*?"">(.*?)</a>\n.*?<a class=""pagebtn""");
    int valueFound;
    bool numberParsed;
    if (normalRegex.IsMatch(myInput)) {
       // your code to check here
       // use int.TryParse to parse your value and add the result to 
       numberParsed = int.TryParse(m2[0].Groups[1].Captures[0].Value, out valueFound);
    }
    if (!numberParsed) {
        if (secondaryRegex.IsMatch(myInput)) {
            // second code matches
        } else {
            // no match
        }
    }
