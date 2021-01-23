    public class Program
    {
    	public static void Main()
    	{
    		string x="aac";
    		string y ="caa";
    		
    	  List<char> lstX = x.ToCharArray().OrderBy(m=>m).ToList<char>();
    	  List<char> lstY =y.ToCharArray().OrderBy(m=>m).ToList<char>();
    		
    		
    		Console.WriteLine(IsAnagramaticPair(x,y));
    	}
    	
    	public static bool IsAnagramaticPair(string x ,string y)
    	{
    		List<char> lstX = x.ToCharArray().OrderBy(m=>m).ToList<char>();
    	  	List<char> lstY =y.ToCharArray().OrderBy(m=>m).ToList<char>();
    		
    		return lstX.SequenceEqual(lstY);
    		
    	}
    }
