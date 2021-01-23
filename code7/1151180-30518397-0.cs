    class Foo
    {
        [Test]
        public void Should_work()
        {
            var myWcfServiceMock = Substitute.For<IChatService>();
            var mockServiceHost = MockServiceHostFactory.GenerateMockServiceHost(myWcfServiceMock , new Uri("http://localhost:8001"), "MyService");
            mockServiceHost.Open();
            mockServiceHost.Close();
        }
        public static class MockServiceHostFactory
        {
            public static ServiceHost GenerateMockServiceHost<TMock>(TMock mock, Uri baseAddress, string endpointAddress)
            {
                var serviceHost = new ServiceHost(mock, new[] { baseAddress });
                serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
                serviceHost.Description.Behaviors.Find<ServiceBehaviorAttribute>().InstanceContextMode = InstanceContextMode.Single;
                serviceHost.AddServiceEndpoint(typeof(TMock), new BasicHttpBinding(), endpointAddress);
                return serviceHost;
            }
        }
    }
