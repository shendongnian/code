    using System;
    using System.Linq;
    using Microsoft.Win32;
    
    public static class Program
    {
    static void Main(string[] args)
    {
        Registry
            .LocalMachine
            .OpenSubKey(@"SYSTEM\CurrentControlSet\Services\EventLog\Application")
            .GetSubKeyNames()
            .ToList()
            .ForEach(source => Console.WriteLine(source));
        }
    }
