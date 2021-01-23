    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    namespace StackOverflow
    {
        class Program
        {
            [DllImport("dnsapi", EntryPoint = "DnsFlushResolverCache")]
            private static extern uint DnsFlushResolverCache();
            static void Main(string[] args)
            {
                //string varibale for hostilfe
                var HOSTFILE = "";
                //set to color c => red
                Console.ForegroundColor = ConsoleColor.Red;
                //Get OperatingSystem information from the system namespace.
                var OSInfo = Environment.OSVersion;
                //Determine the platform.
                if (OSInfo.Platform == PlatformID.Win32NT)
                {
                    //is windows NT
                    HOSTFILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"system32\drivers\etc\hosts");
                }
                else
                {
                    //is no windows NT
                    HOSTFILE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "hosts");
                }
                //print hostfile
                Console.WriteLine(HOSTFILE);
                //get ip address
                IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
                var myIP = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
                //append newline & myip to hostfile
                File.AppendAllLines(HOSTFILE, new[] { "", $"{myIP} download.talesrunner.com" });
                //if the above does not work because you don't have C# 6.0 use the following line
                //File.AppendAllLines(HOSTFILE, new[] { "", string.Format("{0} download.talesrunner.com", myIP)});
                //flush dns cache
                DnsFlushResolverCache();
                //wait for user or sth else unless window will close immediately
                Console.ReadLine();
            }
        }
    }
