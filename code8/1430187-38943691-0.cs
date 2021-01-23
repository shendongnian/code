        using (ServiceHost host = new ServiceHost(typeof(WcfProductService)))
        {
            host.Open();
            Console.WriteLine("server is open");
            Console.ReadLine();
        }
