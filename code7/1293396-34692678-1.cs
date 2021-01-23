    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                      @"c:\folder one\folder2\folder 3",
                      @"\\remoteMachine\folder1",
                      @"\\1.22.33.444\folder 1\folder2",
                      @"ftp://12.123.112.231/",
                      @"C:\Program Files\Google\Chrome"
                                 };
                string ip = @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}";
                string pattern = string.Format( @"^[A-Z]:(\\(\w+\s*)+)+" + // filename
                                 @"|^\\\\{0}(\\(\w+\s*)+)+" +              // url with ip
                                 @"|^\\(\\(\w+\s*)+)+" +                   // network filename \\abc\def
                                 @"|^FTP://{0}/" +                         // ftp with ip
                                 @"|^FTP://[A-Z]\w+/", ip);                // ftp with hostname
                foreach (string input in inputs)
                {
                    bool match = Regex.IsMatch(input,pattern, RegexOptions.IgnoreCase);
                    Console.WriteLine("\"{0}\" {1}", input, match? "matches" : "does not match");
                }
                Console.ReadLine();
            }
        }
    }
    ​
