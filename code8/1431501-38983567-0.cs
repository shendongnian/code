    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("E:\\ip.txt"))
            {
                IP(args, writer);
            }
        }
        static void IP(string[] args, TextWriter writer)
        {
            String StringHost;
            if (args.Length == 0)
            {
                // Getting IP of local machine...
                // First get the host name of the local machine...
                StringHost = System.Net.Dns.GetHostName();
                writer.WriteLine("Local machine host name is: " + StringHost);
                writer.WriteLine("");
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
                writer.WriteLine("");
                writer.WriteLine("IP Address Type {0}: {1} ", i, address[i].ToString());
            }
        }
    }
