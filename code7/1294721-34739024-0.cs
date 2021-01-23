    static void Main(string[] args)
    {
        string sourceFolder = @"C:\dom\Xml";
        string searchWord = @"(\\ |[^ ])+\$#x9\b";
        Regex rule = new Regex(searchWord);
    
        List<string> allFiles = new List<string>();
        AddFileNamesToList(sourceFolder, allFiles);
        foreach (string fileName in allFiles)
        {
    	    string contents = File.ReadAllText(fileName);
    	    if (rule.IsMatch(contents))
    	    {
        	    Console.WriteLine(fileName);
    	    }
        }
    
        Console.WriteLine(" ");
        System.Console.ReadKey();
    }
