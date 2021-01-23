    using System;
    using System.IO;
    namespace StackOverflowQA
    {
        class Program
         {
             static void Main(string[] args)
             {
                if(File.Exists(@"C:\Exercise\Derp\"))
                 {
                   DoWork();
                 }
                 else
                 {
                   Console.Out.Writelne("Wrong kid died");
                   Console.Write("Enter a key to exit");
                   Console.Read();
                 }
                private static void DoWork()
                {
                   
                  //-- if you get to this point then check out that,
                 //    NuGet pkg you're working with (WinSCP) and proceed! :) 
                }
             }
          }
     }
