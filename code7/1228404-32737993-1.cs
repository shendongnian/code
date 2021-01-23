            public static void Main()
            {
                using (ServiceHost host = new ServiceHost(typeof(WcfService1.Service1)))
                {
                    host.Open();
                    Console.WriteLine("Started Report Host");
                    Console.ReadKey();
                }
            }
       
