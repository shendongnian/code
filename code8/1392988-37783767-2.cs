    class Program
    {
    	static string RemoveAfterPDF(string gerneralRootPath)
    	{
    		string pdf = "PDF";
    		int index = gerneralRootPath.IndexOf(pdf);
    		return gerneralRootPath.Substring(0, index + pdf.Length);
    	}
    
    	public static void Main()
    	{
    		string test = RemoveAfterPDF("Documents/Z_Documentation/PDF/sales.2010+Implementation+Revised+Feb10.pdf");
    	}
    }
