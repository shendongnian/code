    static Regex how = new Regex(@"(?<!\bhelp\b.*)\bhow\b", RegexOptions.IgnoreCase);
    static Regex help = new Regex(@"(?<!\bhow\b.*)\bhelp\b", RegexOptions.IgnoreCase);
    
    static void Main(String[] args)
    {
    	Console.WriteLine(helpOrHow("how"));
    	Console.WriteLine(helpOrHow("help"));
    	Console.WriteLine(helpOrHow("Help you how"));
    	Console.WriteLine(helpOrHow("how to help you"));
    }
    
    static string helpOrHow(String text)
    {
    	if (how.IsMatch(text))
    	{
    		return "how";
    	}
    	else if (help.IsMatch(text))
    	{
    		return "help";
    	}
    	return "none";
    }
