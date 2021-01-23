    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Launch();
            AppDomain.CurrentDomain.ExecuteAssembly(@"C:\\path\to\file.exe");
        }
    
    }
