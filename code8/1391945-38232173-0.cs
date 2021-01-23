    // Disable mex ($metadata)
    ServiceMetadataBehavior smb = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
    if (smb == null)
    {
        smb = new ServiceMetadataBehavior();
        smb.HttpsGetEnabled = false;
    }
    host.Description.Behaviors.Add(smb);
    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, 
                    MetadataExchangeBindings.CreateMexHttpsBinding(),
                    "$metadata");
