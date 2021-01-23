    class Program
    {
        static void Main(string[] args)
        {
            var mgr = new NetworkListManager();
            foreach (INetwork network in mgr.GetNetworks(NLM_ENUM_NETWORK.NLM_ENUM_NETWORK_ALL))
            {
                Console.WriteLine("Network: " + network.GetName());
                foreach (INetworkConnection conn in network.GetNetworkConnections())
                {
                    Console.WriteLine(" Adapter Id:  " + conn.GetAdapterId());
                    var ni = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(i => new Guid(i.Id) == conn.GetAdapterId());
                    Console.WriteLine(" Interface: " + ni.Name);
                    Console.WriteLine(" Type: " + ni.NetworkInterfaceType);
                }
            }
        }
    }
