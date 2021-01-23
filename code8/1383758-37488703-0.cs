    namespace ConsoleApplication4
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
    
      public static class StringExtensions
      {
        public static IEnumerable<int> IndexOfSingleLetterBetweenWhiteSpace(this string text)
        {
          return Enumerable.Range(1, text.Length-2)
                           .Where(index => char.IsLetter(text[index]) 
                                        && char.IsWhiteSpace(text[index + 1])
                                        && char.IsWhiteSpace(text[index - 1]));
        }  
      }
    
      class Program
      {
        static void Main()
        {
          var text = "This is a test";
    
          var index = text.IndexOfSingleLetterBetweenWhiteSpace().Single();
    
          Console.WriteLine("There is a single letter '{0}' at index {1}", text[index], index);
          Console.ReadLine();
        }
      }
    }
