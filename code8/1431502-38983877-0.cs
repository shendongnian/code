    using System;
    using System.IO;
    using System.Net;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace IPObtainer
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (StreamWriter writer = new StreamWriter("E:\\ip.txt"))
                {
                    Console.SetOut(writer);
                     IP(args);
                }
            }
    
            static void IP(string[] args)
            {
                String StringHost;
                if (args.Length == 0)
                {
                    // Getting IP of local machine...
                    // First get the host name of the local machine...
                    StringHost = System.Net.Dns.GetHostName();
                    Console.WriteLine("Local machine host name is: " + StringHost);
                    Console.WriteLine("");
    
                }
                else
                {
                    StringHost = args[0];
                }
    
    
                // The using hostname, get the IP address List...
                IPHostEntry ipEntry =
                    System.Net.Dns.GetHostEntry(StringHost);
    
                IPAddress[] address = ipEntry.AddressList;
    
                for (int i = 0; i < address.Length; i++)
                {
                    Console.WriteLine("");
                    Console.WriteLine("IP Address Type {0}: {1} ", i, address[i].ToString());
                }
    
    
            }
        }
    }
