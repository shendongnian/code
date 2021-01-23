    using System;
    using System.Text.RegularExpressions;
    
    public class Program
    {
        public static void Main()
        {
            string line1 = "ban added reason='Posting links to malware websites' cluid='oNNtrNGo6kdxNRshT8MiHlq4wR8=' bantime=0 by client 'Someone'(id:4)";
    		Match m = Regex.Match(line1, "cluid='([^']{27}=)'");
    		if (m.Success)
    		{
    			Console.WriteLine(m.Groups[1]);
    		}
    
    		string line2 = "ban added reason='Posting links to malware websites' cluid='IVz0tUZThCdbBnCWjf+axoMqVTM=' bantime=0 by client 'Someone'(id:4)";
    		m = Regex.Match(line2, "cluid='([^']{27}=)'");
    		if (m.Success)
    		{
    			Console.WriteLine(m.Groups[1]);
    		}
        }
    }
