    using System;
    using System.Diagnostics;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		float[] data = new float[1500000];
    		Random rnd = new Random(12345);
    		
    		for (int i = 0; i < data.Length; i++)
    		{
    			data[i] = (float)(rnd.NextDouble() * 5000.0 - 2500.0);
    		}
    		
    		Stopwatch sw = new Stopwatch();
    		
    		sw.Start();
    		
    		var varsum = 0.0f;  //varsum is a DOUBLE!!!! change this to 0.0f to make them equal!
    		
    		for (int i = 0; i < data.Length; i++)
    			varsum += Math.Max(data[i], 0);        //implicit conversions, float->double, int->float
    		
    		sw.Stop();
    		
    		Console.WriteLine("Varsum : " + varsum);
    		
    		Console.WriteLine("Time it took for the original: " + sw.Elapsed.TotalMilliseconds + " ms");
    		
    		float floatsum = 0.0f;
    		
    		sw.Reset();
    		sw.Start();
    		
    		floatsum = 0.0f;
    		floatsum=data.AsParallel().Where(d=>d>0).Sum();
    		
    		sw.Stop();
    		
    		Console.WriteLine("OptimizedSum: " + floatsum);
    		
    		Console.WriteLine("Time it took for \"optimized\" version: " + sw.Elapsed.TotalMilliseconds + " ms");
    		
    		//Equality on floating point numbers doesn't work like this, but...
    		Console.WriteLine("Are these two equal? " + (floatsum == varsum).ToString());
    		Console.WriteLine("How close are they? " + Math.Abs(floatsum - varsum).ToString("00.0000000000000000"));
    
    	}
    }
