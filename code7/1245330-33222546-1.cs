    using System;
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
                {
                    using (var writer = new StreamWriter(filename, true))
                    {
                        foreach (var website in lstWebSites)
                        {
                            var roundTripTimes = new List<long>();
    
                            for (var i = 0; i < 4; i++)
                            {
                                try
                                {
                                    var myPing = new Ping();
                                    var reply = myPing.Send(website, 1000);
   
                                    if (reply != null)
                                    {
                                        roundTripTimes.Add(reply.RoundtripTime);
                                    }
                                }
                                catch
                                {
                                    Console.WriteLine("ERROR: You have some TIMEOUT issue");
                                }
                            }
                            writer.WriteLine("{0} , {1}", website, string.Join(" , ", roundTripTimes));
                        }
                    }
                }
                Console.ReadKey();
            }
        }
    }
