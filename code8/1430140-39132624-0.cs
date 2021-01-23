    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApplication99
    {
      class Program
      {
        static void Main(string[] args)
        {
          string fileContent = "....."; // a large string 
          // --- high perf section to count all chars ---
          var charCounter = new int[char.MaxValue + 1];
          for (int i = 0; i < fileContent.Length; i++)
          {
            charCounter[fileContent[i]]++;
          }
          // --- combine results with linq (all actions consume less than 1 ms) ---
          var allResults = charCounter.Select((count, index) => new { count, charValue = (char)index }).Where(c => c.count > 0).ToArray();
          var spaceChars = new HashSet<char>(" ,:;");
          int countSpaces = allResults.Where(c => spaceChars.Contains(c.charValue)).Sum(c => c.count);
          var usefulChars = new HashSet<char>("abcdefghijklmnopqrstuvwxyz");
          int countLetters = allResults.Where(c => usefulChars.Contains(c.charValue)).Sum(c => c.count);
        }
      }
    }
