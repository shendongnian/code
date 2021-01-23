    using System;
    namespace ConsoleApp1
    {
       public class Program
       {
          public static void Main(string[] args)
          {
             string content = System.IO.File.ReadAllText("MyTextFile.txt");
     #if DNX451
             Console.WriteLine("NET451");
     #elif DNXCORE50
             Console.WriteLine("DNXCORE50");
     #endif
             Console.WriteLine(content);
             Console.ReadLine();
          }
       }
    }
