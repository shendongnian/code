    class ProgramClient
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("John Doe");
                IChatServiceCallback callback = new SimpleChatCallback();
                InstanceContext instanceContext = new InstanceContext(callback);
                ChatServiceClient serviceProxy = new ChatServiceClient(instanceContext);
                Console.WriteLine("Endpoint:");
                Console.WriteLine("***********************************************");
                Console.WriteLine(string.Format("Address = {0}", serviceProxy.Endpoint.Address));
                Console.WriteLine(string.Format("Binding = {0}", serviceProxy.Endpoint.Binding));
                Console.WriteLine(string.Format("Contract = {0}", serviceProxy.Endpoint.Contract.Name));
                Person[] people = serviceProxy.Join(person);
                Console.WriteLine("***********************************************");
                Console.WriteLine("Connected !");
                Console.WriteLine("Online users:");
                foreach (Person p in people)
                    Console.WriteLine(p.Name);
                Console.WriteLine("Press <ENTER> to finish...");
                Console.ReadLine();
                if (serviceProxy.State != CommunicationState.Faulted)
                    serviceProxy.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
