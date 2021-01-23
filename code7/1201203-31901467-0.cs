    using System;
    using System.Globalization;
    
    namespace MyCOnsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string pattern1 = "dd/MMM";
                string pattern2 = "dd-MMM";
                DateTime parsedDate;
                string input = "hello 12/May 789";//your string
                string[] results = input.Split(new string[] { " " }, StringSplitOptions.None);
    
                foreach (var result in results)
                {
                    //pattern1
                    if (DateTime.TryParseExact(result, pattern1, CultureInfo.InvariantCulture,
                                              DateTimeStyles.None, out parsedDate))
                        Console.WriteLine("Converted '{0}' to {1:d} by pattern1.",
                                          result, parsedDate);
                    //pattern2
                    else if (DateTime.TryParseExact(result, pattern2, CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out parsedDate))
                        Console.WriteLine("Converted '{0}' to {1:d} by pattern2.",
                                          result, parsedDate);
                    else
                        Console.WriteLine("Unable to convert '{0}' to a date and time.",
                                          result);
                }
    
                //splitted values
                foreach (string s in results)
                    Console.WriteLine(s);
              
                Console.ReadLine();
    
            }
        }
    }
