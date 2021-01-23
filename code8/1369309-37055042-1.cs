    public class Program
    {
    	public static void Main()
    	{
    		int? one = 1;
    		int? two = 1;
    		int? three = 1;
    		
    		int? nullOne = null;
    		int? nullTwo = null;
    		int? nullThree = null;
    		
    		Console.WriteLine(ArePartiallyNull(one, two, three));
    		Console.WriteLine(ArePartiallyNull(nullOne, nullTwo, nullThree));
    		Console.WriteLine(ArePartiallyNull(one, two, nullThree));
    	}
    	
    	private static bool ArePartiallyNull(params object[] values)
    	{
    		if(values.Length <= 1)
    			return false;
    		
    		var isNull = values[0] == null;
    		
    		for(var i = 1;i < values.Length;i++)
    		{
    			if(isNull != (values[i] == null))
    				return true;
    		}
    		
    		return false;
    	}
    }
