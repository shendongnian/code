    // cmdline2.cs
    // arguments: John Paul Mary
    using System;
    public class CommandLine2
    {
       public static void Main(string[] args)
       {
           Console.WriteLine(
             "Number of command line parameters = {0}",
              args.Length);
           foreach (string s in args) Console.WriteLine(s);
           
           Console.WriteLine("Hit any key to exit");
           Console.ReadLine();
       }
    }
