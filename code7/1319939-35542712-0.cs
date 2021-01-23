    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    public class Test
    {
    	private static readonly Regex rx = new Regex(@"\([^()]*\)$", RegexOptions.Compiled);
    	public static void Main()
    	{
    		var strs = new string[] {"this is a string (dsdfgfg)","this is a (string (123456)",
    			"this is a (string) (FF4455GG)","this is a string (fdf","this is a string (dsdfgfg) temp",
    			"this is a string (dsdfgfg))"};
            foreach (var s in strs) 
            {
            	Console.WriteLine(string.Format("{0}: {1}", s, rx.IsMatch(s).ToString()));
            }
    	}
    }
