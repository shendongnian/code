    using System;
    using System.Text.RegularExpressions;
    namespace RegExApplication
    {
    class Program
    {
      private static void showMatch(string text, string expr)
      {
         int count=0;
         Console.WriteLine("The Expression: " + expr);
         MatchCollection mc = Regex.Matches(text, expr);
         foreach (Match m in mc)
         {
            count++;
         }
         Console.WriteLine(expr+" found "+count+" number of times");
      }
      static void Main(string[] args)
      {
         string str = "1P2R1P2R1P2R1P2R1P2R1P2R1P2R1P2RGIRISHBALODI";
         Console.WriteLine("Matching words that start with 'S': ");
         showMatch(str, @".P");
         showMatch(str, @".R");
         Console.ReadKey();
      }
    }
    }
