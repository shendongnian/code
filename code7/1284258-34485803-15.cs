    class ProgramHost
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(ChatLib.ChatService));
                host.Open();
                Console.WriteLine(string.Format("WCF {0} host is running...", host.Description.ServiceType));
                Console.WriteLine("Endpoints:");
                foreach (ServiceEndpoint se in host.Description.Endpoints)
                {
                    Console.WriteLine("***********************************************");
                    Console.WriteLine(string.Format("Address = {0}", se.Address));
                    Console.WriteLine(string.Format("Binding = {0}", se.Binding));
                    Console.WriteLine(string.Format("Contract = {0}", se.Contract.Name));
                }
                Console.WriteLine(string.Empty);
                Console.WriteLine("Press <ENTER> to terminate.");
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
