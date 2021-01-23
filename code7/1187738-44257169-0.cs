     public void ConnectToMSCRM(string UserName, string Password, string ServiceUri)
        {
            try
            {
                ClientCredentials credentials = new ClientCredentials();
                credentials.UserName.UserName = UserName;
                credentials.UserName.Password = Password;
                Uri serviceUri = new Uri(ServiceUri);
                OrganizationServiceProxy proxy = new OrganizationServiceProxy(serviceUri, null, credentials, null);
                proxy.EnableProxyTypes();
                _service = (IOrganizationService)proxy;
                Response.Write("\n Connected to CRM \n\n");
    
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("\n Error is :  \n\n" + ex.Message);
            }
        }
