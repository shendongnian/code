    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    // And then...
    var strs = new List<string> { "(1,89,10,10)", "(1,14,10,10),(2,13,11,12)"};
    var pattern = @"^\(\s*(?<type>\d+)\s*,\s*(?<year>\d+)\s*,\s*(?<agestart>\d+)\s*,(?<ageend>\d+)\s*\)\s*(,\s*\(\s*(?<type>\d+)\s*,\s*(?<year>\d+)\s*,\s*(?<agestart>\d+)\s*,(?<ageend>\d+)\s*\)\s*)*$";
    foreach (var s in strs)
    {
      	var match = Regex.Match(s, pattern, RegexOptions.ExplicitCapture);	
       	if (match.Success) 
       	{
       		Console.WriteLine(string.Join(", and ", match.Groups["type"].Captures.Cast<Capture>().Select(m => m.Value).ToList()));
       		Console.WriteLine(string.Join(", and ", match.Groups["year"].Captures.Cast<Capture>().Select(m => m.Value).ToList()));
       		Console.WriteLine(string.Join(", and ", match.Groups["agestart"].Captures.Cast<Capture>().Select(m => m.Value).ToList()));
       		Console.WriteLine(string.Join(", and ", match.Groups["ageend"].Captures.Cast<Capture>().Select(m => m.Value).ToList()));
       	}
    }
