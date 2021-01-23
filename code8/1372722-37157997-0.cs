    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;
    public class Test
    {
    	public static void Main()
    	{
    		var variablesDictionary = new Dictionary<string, string>();
    		variablesDictionary.Add("$$@Key", "Value");
    		var pattern = @"\$\$@[a-zA-Z0-9_]+\b";
    		var stringVariableMatches = Regex.Replace("$$@Unknown and $$@Key", pattern, 
    		        m => variablesDictionary.ContainsKey(m.Value) ? variablesDictionary[m.Value] : m.Value);
    		Console.WriteLine(stringVariableMatches);
    	}
    }
