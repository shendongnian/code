    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		int i;
    		int satir, sutun;
    		Console.WriteLine("Kaç satır olsun?");
    		satir = Convert.ToInt32(Console.ReadLine());
    		Console.WriteLine("Kaç sütun olsun peki?");
    		sutun = Convert.ToInt32(Console.ReadLine());
    		for (i = 1; i <= sutun * satir; i++)
    		{
    			Console.Write("*");
    			if (i % sutun == 0)
    			{
    				Console.Write("\n");
    			}
    		}
    	}
    }
