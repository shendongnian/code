    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main()
        {
            string line = "ban added reason='Posting links to malware websites' cluid='oNNtrNGo6kdxNRshT8MiHlq4wR8=' bantime=0 by client 'Someone'(id:4)";
    		Match m = Regex.Match(line, "cluid='([^']{27}=)'");
    		if (m.Success)
    		{
    			Console.WriteLine(m.Groups[1]);
    		}
    
        }
    }
