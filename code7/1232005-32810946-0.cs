    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] parts = new string[100];
    
                var text = "47-62*5141";
                int i = 0;
    
                var splittedText = text.SplitAndKeepSeparator('-', '*', '+', '/');
    
                foreach (var part in splittedText)
                {
                        parts[i] = part;
                        i++;
                        
                }
                Console.ReadLine();
                Console.WriteLine(parts[0]);
                Console.WriteLine(parts[1]);
                Console.WriteLine(parts[2]);
                Console.WriteLine(parts[3]);
                Console.ReadLine();
            }
        }
    }
    public static class StringExtensions
    {
        public static IEnumerable<string> SplitAndKeepSeparator(this string s, params char[] seperators)
        {
            var parts = s.Split(seperators, StringSplitOptions.None);
    
            var partIndex = 0;
            var isPart = true;
            var indexInText = 0;
            while (partIndex < parts.Length)
            {
                if (isPart)
                {
                    var partToReturn = parts[partIndex];
    
                    if (string.IsNullOrEmpty(partToReturn))
                    {
                        partToReturn = s[indexInText].ToString();
                    }
                    else
                    {
                        isPart = false;
                    }
                    indexInText += partToReturn.Length;
                    partIndex++;
    
                    yield return partToReturn;
                }
                else
                {
                    var currentSeparator = s[indexInText];
                    indexInText++;
                    isPart = true;
                    yield return currentSeparator.ToString();
                }
            }
        }
    }
