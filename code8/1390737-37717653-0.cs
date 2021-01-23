    using System;
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main()
        {
            var re =  new Regex(@"^([\w ]{0,30})$", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //Console.WriteLine(re.Match("ACUÑA").Success);
            Console.WriteLine(re.IsMatch("ACUÑA")); // Should print "True"
        }
    }
