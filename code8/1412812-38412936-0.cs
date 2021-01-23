      using(ServiceHost myServ = new ServiceHost(typeof(HelloWorldService), baseAdress))
    {
                
                    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
                    myServ.Description.Behaviors.Add(smb);
                    myServ.Open();
                    MessageBox.Show("Services is :" + myServ.State + "\n" + baseAdress);
        }
