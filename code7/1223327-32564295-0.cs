    var allLines = new List<string>();
    for (int i = 0; i < 5; i++)
    {
         allLines.Add("test" + i);
    }
    // if you add this line, it will fail because the last line doesn't match the reg ex
    allLines.Add("test");
    var myRegEx = @"\w*\d"; // <- find the regex that match your lines
    Regex regex = new Regex(myRegEx);
    var success = allLines.All(line => regex.Match(line).Success);
