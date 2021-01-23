    namespace WcfTestClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                EndpointAddress endpointAddress = new EndpointAddress(@"http://localhost/Service1.svc");
    
                BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
                basicHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
                basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
    
                var channelFactory = new ChannelFactory<WcfTestService.IService1>(basicHttpBinding, endpointAddress);
                channelFactory.Credentials.UserName.UserName = @"server\someuser";
                channelFactory.Credentials.UserName.Password = @"somepass";
                try
                {
                    var client = channelFactory.CreateChannel();
                    string a = client.GetData(55);
                    Console.Write(e.Message);
                }
                catch (Exception e)
                {
                    Console.Write(e.Message);
                }
            }
        }
    }
