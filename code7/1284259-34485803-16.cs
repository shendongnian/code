    class ProgramClient
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                    Console.WriteLine("usage: clientconsole username");
                else
                {
                    Person user = new Person(args[0]);
                    IChatServiceCallback callback = new SimpleChatCallback();
                    InstanceContext instanceContext = new InstanceContext(callback);
                    ChatServiceClient serviceProxy = new ChatServiceClient(instanceContext);
                    Console.WriteLine("Endpoint:");
                    Console.WriteLine("***********************************************");
                    Console.WriteLine(string.Format("Address = {0}", serviceProxy.Endpoint.Address));
                    Console.WriteLine(string.Format("Binding = {0}", serviceProxy.Endpoint.Binding));
                    Console.WriteLine(string.Format("Contract = {0}", serviceProxy.Endpoint.Contract.Name));
                    Person[] people = serviceProxy.Join(user);
                    Console.WriteLine("***********************************************");
                    Console.WriteLine("Connected !");
                    Console.WriteLine("Online users:");
                    foreach (Person p in people)
                        Console.WriteLine(p.Name);
                    string msg;
                    while ((msg = Console.ReadLine()) != "exit")
                        serviceProxy.Say(msg);
                    serviceProxy.Leave();
                    if (serviceProxy.State != CommunicationState.Faulted)
                        serviceProxy.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
