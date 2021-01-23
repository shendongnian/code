    void Main()
    {
    	var stringToReplace = "ABC_test\\/:*?\"<>|_Jan2016_ABC";
        string pattern = "[\\\\~#%&*{}//:<>?|\"-]";
        Regex regEx = new Regex(pattern);
        var final = regEx.Replace(stringToReplace, "_");
        Console.WriteLine(final);
    }
