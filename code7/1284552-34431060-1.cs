    using System;
    using System.Threading.Tasks;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Program.DoIt().Wait();
    	}
    	
    	private static async Task DoIt()
    	{
    		System.Net.WebClient wc = new System.Net.WebClient();
    		var task1 = wc.DownloadStringTaskAsync("https://www.google.com.au");
    		Console.WriteLine(await task1);
    		Console.WriteLine("done!"); 
    	}
    }
