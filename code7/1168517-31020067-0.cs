        using System;
        using System.Collections.Generic;
        using System.Linq;
        namespace tcp_ports
        {
            using System.Net.NetworkInformation;
            using System.Threading;
            class Program
            {
                static void Main(string[] args)
                {
                    do
                    {
                        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                        TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
                        Dictionary<String, int> ips = new Dictionary<string, int>();
                        Dictionary<String, String> ipsLocal = new Dictionary<String, String>();
                        Console.Clear();
                        Console.WriteLine("Number of open TCP Connections = {0}", connections.Count());
                        Console.WriteLine("=========================================");
                        foreach (TcpConnectionInformation c in connections)
                        {
                            String ip = c.RemoteEndPoint.Address.ToString();
                            if (ips.ContainsKey(ip))
                            {
                                ips[ip]++;
                                ipsLocal[ip] = c.LocalEndPoint.Address.ToString();
                            }
                            else
                            {
                                ips.Add(ip, 1);
                                ipsLocal.Add(ip, c.LocalEndPoint.Address.ToString());
                            }
                        }
                        var sortedIPs = from entry in ips orderby entry.Value descending select entry;
                        int no = 20;
                        foreach (var ip in sortedIPs)
                        {
                            Console.WriteLine("{0} <==> {1} = {2}", ip.Key, ipsLocal[ip.Key], ip.Value);
                            if (--no < 0) break;
                        }
                        Thread.Sleep(1000);
                    } while (true);
                }
            }
        }
