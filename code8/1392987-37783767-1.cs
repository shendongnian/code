    class Program
    {
    	static string RemoveAfterPDF(string gerneralRootPath, string removeAfter)
    	{
    		string result = string.Empty;
    		int index = gerneralRootPath.IndexOf(removeAfter);
    
    		if (index > 0)
    		    result = gerneralRootPath.Substring(0, index + removeAfter.Length);
    
    		return result;
    	}
    
    	public static void Main()
    	{
    		string test = RemoveAfterPDF("Documents/Z_Documentation/PDF/sales.2010+Implementation+Revised+Feb10.pdf", "PDF");
    	}
    }
