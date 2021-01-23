        static void Main(string[] args)
        {
            try
            {
                string address = "http://localhost:9003/FooService";
                Uri addressBase = new Uri(address);
                var svcHost = new ServiceHost(typeof(FooService), addressBase);
                 BasicHttpBinding bHttp = new BasicHttpBinding();
                //Type contractType = typeof(IFooService);
                //ContractDescription contractDescription = new ContractDescription(contractType.Name);
                //contractDescription.ProtectionLevel = ProtectionLevel.None;
                //contractDescription.ContractType = contractType;
                //contractDescription.ConfigurationName = contractType.FullName;
                //contractDescription.SessionMode = SessionMode.NotAllowed;
                //svcHost.AddServiceEndpoint(new ServiceEndpoint(contractDescription, bHttp, new EndpointAddress(address)));
                svcHost.AddServiceEndpoint(typeof(IFooService).ToString(), bHttp, address);
                svcHost.Open();
                Console.WriteLine("\n\nService is Running as >> " + address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
