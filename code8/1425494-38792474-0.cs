    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    
    	public void Main()
    	{
    		Stopwatch sw = new Stopwatch();
    		
    		sw.Start();
    		
    		for (int i=0; i < 500; i++)
    		{
    			Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    			string rawString = "house home go www.monstermmorpg.com nice hospital http://www.monstermmorpg.com this is incorrect url http://www.monstermmorpg.commerged continue";
    		}
    		
    		sw.Stop();
    		
    		var test1Time = sw.ElapsedMilliseconds;
    		
    		
    		sw.Reset();
    		sw.Start();
    		
    		for (int i=0; i < 500; i++)
    		{
    			string rawString = "house home go www.monstermmorpg.com nice hospital http://www.monstermmorpg.com this is incorrect url http://www.monstermmorpg.commerged continue";
    			var links = rawString.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => s.StartsWith("http://") || s.StartsWith("www.") || s.StartsWith("https://"));	
    		}
    		
    		sw.Stop();
    		
    		var test2Time = sw.ElapsedMilliseconds;
    		
    		Console.WriteLine("Regex Test: " + test1Time.ToString());
    		Console.WriteLine("Split Test: " + test2Time.ToString());
    	}
    }
