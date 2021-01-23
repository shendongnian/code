    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string[] a1 = { "cat", "bird", "dog" };
            string[] a2 = { "cat", "dog", "bird" };
            string[] a3 = { "cat", "fish", "dog" };
    
            Console.WriteLine(a1.GetHashCode());
            Console.WriteLine(a2.GetHashCode());
            Console.WriteLine(a3.GetHashCode());
    	}
    }
