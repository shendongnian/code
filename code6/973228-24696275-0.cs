    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    public class Test
    {
        public static void Main()
        {   
    		string[] tests = new string[]{
    		    @"*\\*",
    		    @"*\\\**",
    		    @"*\**",
    		};
    		
    		Regex re = new Regex(@"(?:[^*\\]+|\\.)+|\*");
    		
    		foreach (string s in tests) {
    			var parts = re.Matches(s)
                 .OfType<Match>()
                 .Select(m => m.Value)
                 .ToList();
                 
    		    Console.WriteLine(string.Join(", ", parts.ToArray()));
    		}
        }
    }
