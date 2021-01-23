    using MyNamespace.something;
    using System;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" " + typeof(FuncResultCode));
            Console.ReadLine();
        }
    }
   }
    namespace MyNamespace.something
    {
    public enum FuncResultCode
    {
        SUCCESS,
        MISSING_INFO,
        UNALLOWED_CHANGES
     }
    }
