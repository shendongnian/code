    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            static void Main(string[] args)
            {
                StreamReader reader = new StreamReader(FILENAME);
                string inputLine = "";
                string pattern1 = @"^\[(?'datetime'[^\]]*)\](?'message'[^$]*)";
                Regex expr = new Regex(pattern1, RegexOptions.Multiline);
                while ((inputLine = reader.ReadLine()) != null)
                {
                    inputLine = inputLine.Trim();
                    Match match = expr.Match(inputLine);
                    string x = match.Groups["datetime"].Value;
                    DateTime date = DateTime.Parse(match.Groups["datetime"].Value);
                    string message = match.Groups["message"].Value;
                    if (message.Contains(":"))
                    {
                        string[] array = message.Split(new char[] { ':' });
                        switch (array[0].Trim())
                        {
                            case "SV_ET_CMD_TYPE.SV_ET_CMD_SCAN" :
                                Console.WriteLine("Number : {0}", array[1].Trim());
                                break;
                        }
                    }
                }
                Console.ReadLine();
            }
        }
    }
    ​
