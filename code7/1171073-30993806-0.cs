    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		int[] array1 = new int[20000];
    		int[] array2 = new int[20000];
    		int[] square = new int[20000];
    		int[] product = new int[20000];
    		
    		Random r = new Random();
    		for (int i = 0; i < array1.Length; i++)
    		{
    			array1[i] = r.Next(1, 10);
    			array2[i] = r.Next(1, 10);
    			
    			square[i] = array1[i] * array1[i];
    			product[i] = array1[i] * array2[i];
    		}
    		
    		// Only displaying the first 20 results
    		Console.WriteLine("Array1 : {0}", String.Join(",", array1.Take(20)));
    		Console.WriteLine("Array2 : {0}", String.Join(",", array2.Take(20)));
    		Console.WriteLine("Square : {0}", String.Join(",", square.Take(20)));
    		Console.WriteLine("Product: {0}", String.Join(",", product.Take(20)));
    	}
    }
