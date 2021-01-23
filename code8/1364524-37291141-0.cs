    WebServiceHost host1 = new WebServiceHost(typeof(REST), new Uri("http://localhost:8090/"));
    host1.AddServiceEndpoint(typeof(IREST), new WebHttpBinding(), "rest");
    host1.Description.Endpoints[0].Behaviors.Add(new WebHttpBehavior { HelpEnabled = true });
    host1.Open();
    ServiceHost host2 = new ServiceHost(typeof(SOAP), new Uri("http://10.121.72.214:8090/soap"));
    host2.AddServiceEndpoint(typeof(ISOAP), new WSDualHttpBinding(), "");
    ServiceMetadataBehavior smb = host2.Description.Behaviors.Find<ServiceMetadataBehavior>();
    if (smb == null)
    {
        smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
        host2.Description.Behaviors.Add(smb);
        host2.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
    }
    host2.Open();
    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    Console.WriteLine("Host is opened.");
    Console.ReadKey();
    host1.Close();
    host2.Close();
