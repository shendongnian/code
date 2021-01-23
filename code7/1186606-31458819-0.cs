    List<string> fileNames = new List<string>()
    {
        "xxxxSystemCheckedOut.png",         // Good
        "SystemCheckedOut.png",             // Bad - No prefix
        "1234afweiljSystemCheckedOut.png",  // Good
        "xxxxxxxSystemCheckedOut.bmp"       // Bad - Wrong file extension
    };
    string pattern = "(\\w+)(System)(CheckedOut)(\\.png)";
            
    foreach (string fileName in fileNames)
    {
        Match match = Regex.Match(fileName, pattern);
        if (match.Success)
        {
            Console.WriteLine("File matched");
            Console.WriteLine(match.Groups[1]);
            Console.WriteLine(match.Groups[2]);
            Console.WriteLine(match.Groups[3]);
            Console.WriteLine(match.Groups[4]);
            Console.WriteLine();
        }
    }
