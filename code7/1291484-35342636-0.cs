    protected void Application_Start(object sender, EventArgs e)
        {
            FederatedAuthentication.ServiceConfigurationCreated += new EventHandler<Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs>(FederatedAuthentication_ServiceConfigurationCreated);
           
        }
        void FederatedAuthentication_ServiceConfigurationCreated(object sender, Microsoft.IdentityModel.Web.Configuration.ServiceConfigurationCreatedEventArgs e)
        {
            var cookieProtectionCertificate = CertificateUtil.GetCertificate(StoreName.My,
                StoreLocation.LocalMachine, "CN=myTestCert");
            
            e.ServiceConfiguration.SecurityTokenHandlers.AddOrReplace(
                new SessionSecurityTokenHandler(new System.Collections.ObjectModel.ReadOnlyCollection<CookieTransform> (
                    new List<CookieTransform>
                    {
                        new DeflateCookieTransform(),
                        new RsaEncryptionCookieTransform(cookieProtectionCertificate),
                        new RsaSignatureCookieTransform(cookieProtectionCertificate)
                    })
                ));
        } 
