    public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
    {
        foreach (ServiceEndpoint item in serviceDescription.Endpoints)
        {
            string theScheme = item.Binding.Scheme;
        }
    }
