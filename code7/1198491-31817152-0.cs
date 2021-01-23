    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string st = "abc+{(a,b,c),(d,e,f),(r,s,t),(u,v,y)}+test-{(a,b),(c,d,e)}+rst+{(a,b),(c,d)}";
    		Regex oRegex = new Regex(@"{([^}]+)}");
    		foreach (Match mt in oRegex.Matches(st))
    		{
    			MatchCollection mCol = Regex.Matches(mt.Value, "\\([^)]+\\)");
    			if (mCol.Count == mCol.Cast<Match>().Where(m => m.Length == mCol[0].Length).Count())
    			{
    				Console.WriteLine(mt.Value);
    			}
    		}
    	}
    }
