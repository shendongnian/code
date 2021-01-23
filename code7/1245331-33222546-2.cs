    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.NetworkInformation;
    namespace ConsoleApplication1 
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var lstWebSites = new List<string>
                {
                    "www.yahoo.com",
                    "www.att.com",
                    "www.verizon.com"
                };
                var filename = @"PingLog.csv";
                var pings = Enumerable.Range(0, 4).SelectMany(_ => lstWebSites.Select(ws => new {Ping = new Ping(), WebSite = ws}));
                var result = pings.Select(_ => new {Reply = _.Ping.Send(_.WebSite, 1000), _.WebSite}).ToLookup(_ => _.WebSite, p => p.Reply.RoundtripTime);
                using (var writer = new StreamWriter(filename, true))
                {
                    foreach (var res in result)
                    {
                        writer.WriteLine("{0}, {1}", res.Key, string.Join(" , ", res));
                    }
                }
                Console.ReadKey();
            }
        }
    }
