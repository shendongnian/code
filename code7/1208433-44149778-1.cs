    using System;
    using System.IO;
    using W3CParser.Extensions;
    using W3CParser.Instrumentation;
    using W3CParser.Parser;
    
    namespace W3CParser
    {
        class Program
        {
            static void Main(string[] args)
            {            
                var reader = new W3CReader(File.OpenText(args.Length > 0 ? args[0] : "Data/foobar.log"));
             
                using (new ConsoleAutoStopWatch())
                {
                    foreach (var @event in reader.Read())
                    {
                        Console.WriteLine("{0} ({1}):{2}/{3} {4} (bytes sent)",
                                          @event.Status.ToString().Red().Bold(),
                                          @event.ToLocalTime(),
                                          @event.UriStem.Green(),
                                          @event.UriQuery,
                                          @event.BytesSent);
                    }
                }
            }
        }
    }
