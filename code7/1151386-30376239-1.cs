    public class Test
    {
    	public static void Main()
    	{
    		var list = new List<double[]>
    		    {
    		        new[] { 1.0, 2.0, 3.0, 4.0, 5.0 }
    		    };
    		Console.WriteLine(
                list.Any(a => a.SequenceEqual(new[] { 5.0, 4.0, 3.0, 2.0, 1.0 })));
    		Console.WriteLine(
                list.Any(a => a.SequenceEqual(new[] { 1.0, 2.0, 3.0, 4.0, 5.0 })));
    	}
    }
