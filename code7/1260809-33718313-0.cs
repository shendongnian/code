    using System;
    using System.Text.RegularExpressions;
    using System.IO;
    using System.Linq;
    public class Test
    {
    	public static void Main()
    	{
    		var input = "abc(test)def(rst(another test)uv)xy";
    		var regex = new Regex(@"(?=(\(([^()]+| (?<Level>\()| (?<-Level>\)))+(?(Level)(?!))\)))", RegexOptions.IgnorePatternWhitespace);
    		var results = regex.Matches(input).Cast<Match>()
    		               .Select(p => p.Groups[1].Value)
    		               .ToList();
    		Console.WriteLine(String.Join(", ", results));
    	}
    }
