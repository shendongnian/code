    using System;
    public class Program
    {
    	public static void Main()
    	{
    		var result = "ABC123".Substring("ABC".Length);
    		Console.WriteLine(result);
    		Console.WriteLine("---");
    		
    		Test(SubstringAfter_Remove);
    		Test(SubstringAfter_Substring);
    	}
    	
    	public static void Test(Func<string, string, string> f)
    	{
    		var array = 
    			new string[] { "ABC123", "ABC13245", "ABC123456", "ABC1"};
    		
    		var sw = new System.Diagnostics.Stopwatch();
    		
    		sw.Start();
    		foreach(var s in array) {
    			Console.WriteLine(f.Invoke(s, "ABC"));
    		}
    		sw.Stop();
    		Console.WriteLine(f.Method.Name + " : " + sw.ElapsedTicks + " ticks.");
    		Console.WriteLine("---");
    	}
    	
    	public static string SubstringAfter_Remove(string s, string after)
    	{
    		return s.Remove(0, after.Length);
    	}
    	
    	public static string SubstringAfter_Substring(string s, string after)
    	{
    		return s.Substring(after.Length);		
    	}
    }
