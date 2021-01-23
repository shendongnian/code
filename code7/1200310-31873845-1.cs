    using Histogram = System.Collections.Generic.List<int>;
    
    namespace TEST
    {
    	using FeatureHistogram = System.Collections.Generic.Dictionary<string, Histogram>;
    
    	public class Program
    	{    
    		public static void Main()
    		{
    			var x = new Histogram();
    			Console.WriteLine(x.GetType());
    			
    			var y = new FeatureHistogram();
    			Console.WriteLine(y.GetType());
    		}	
    	}
    }
