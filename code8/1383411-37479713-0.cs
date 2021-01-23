where `(?<Name>\p{L}+)` matches any 1+ Unicode letters and captures it into Group with name "Name", `\s+` matches one or more whitespaces, `(?<Code>\p{L}\d{3})` matches and captures into Group "Code" a letter followed with 3 digits exactly (use `+` instead of `{3}` to match 1 or more digits).
Note that `\b` are word boundaries that help match the strings inside larger strings as whole words.
In C#:
    var pattern = @"\bThese masters were created using (?<Name>\p{L}+)\s+(?<Code>\p{L}\d{3})\b";
Sample demo:
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		var s = "aaaaaa These masters were created using Kevin O014\nThese masters were created using Jhon A039\nThese masters were created using Geeth P034\nThese masters were created using Jemes M077\nThese masters were created using Anne H058\nThese masters were created using JANE S345 aaaaa";
            var matches = Regex.Matches(s, @"\bThese masters were created using (?<Name>\p{L}+)\s+(?<Code>\p{L}\d{3})\b")
    					.Cast<Match>()
    					.Select(m=> string.Format("{0}: {1}", m.Groups["Name"].Value, m.Groups["Code"].Value))
    					.ToList();
            Console.WriteLine(string.Join("\n", matches));
    	}
    }
  [1]: http://regexstorm.net/tester?p=%5cbThese+masters+were+created+using+(%3f%3cName%3e%5cp%7bL%7d%2b)%5cs%2b(%3f%3cCode%3e%5cp%7bL%7d%5cd%7b3%7d)%5cb&i=These+masters+were+created+using+Kevin+O014%0d%0aThese+masters+were+created+using+Jhon+A039%0d%0aThese+masters+were+created+using+Geeth+P034%0d%0aThese+masters+were+created+using+Jemes+M077%0d%0aThese+masters+were+created+using+Anne+H058%0d%0aThese+masters+were+created+using+JANE+S345&o=m
