    using System;
    using System.Linq;
    using System.Diagnostics;
    
    public static class Program
    {
        static void Main(string[] args)
        {
            new EventLog("Application")
                .Entries
                .Cast<EventLogEntry>()
                .Select(entry => entry.Source)
                .Distinct()
                .ToList()
                .ForEach(source => Console.WriteLine(source));
        }
    }
