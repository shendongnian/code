    using System;
    public class Program
    {
       public static void Main()
       {
          Console.WriteLine("Hello World".ContainsSubstring("Henry"));
          Console.WriteLine("Hello World".ContainsSubstring("Hank"));
          Console.WriteLine("12345".ContainsSubstring("12abc"));
       }
    }
    public static class MyExtensions
    {
       public static bool ContainsSubstring(this string str, string compareValue)
       {
          const int charsToCompare = 2;
          var subString = compareValue.Substring(0, Math.Min(charsToCompare, compareValue.Length));
          if (str.Contains(subString))
          {
             return true;
          }
          else if (compareValue.Length > charsToCompare)
          {
             return str.ContainsSubstring(compareValue.Substring(1));
          }
          return false;
       }
    }
