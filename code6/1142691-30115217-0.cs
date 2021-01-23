    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "Car: volvo Wheels: 4 doors: 5";
                string pattern = @"Car:\s+(?'Car'[^\s]+)\s+Wheels:\s+(?'Wheels'[^\s]+)\s+doors:\s+(?'Doors'[^\s]+)";
                Match match = Regex.Match(input, pattern);
                string car = match.Groups["Car"].Value;
                string wheels = match.Groups["Wheels"].Value;
                string doors = match.Groups["Doors"].Value;
            }
        }
    }
    ​
