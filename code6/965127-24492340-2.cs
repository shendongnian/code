        protected void Application_Start()
        {
            FederatedAuthentication.ServiceConfigurationCreated += 
                        new EventHandler<ServiceConfigurationCreatedEventArgs>(FederatedAuthentication_ServiceConfigurationCreated);
        }
        private static void FederatedAuthentication_ServiceConfigurationCreated(Object sender, ServiceConfigurationCreatedEventArgs e)
        {
            const string allowedAudience = "allowed_aud";
            const string certThumbprint = "thumb";
            const string certName = "name";
            var serviceConfiguration = new ServiceConfiguration();
            serviceConfiguration.AudienceRestriction.AllowedAudienceUris.Add(new Uri(allowedAudience));
            var issuerNameRegistry = new ConfigurationBasedIssuerNameRegistry();
            issuerNameRegistry.AddTrustedIssuer(certThumbprint, certName);
            serviceConfiguration.IssuerNameRegistry = issuerNameRegistry;
            serviceConfiguration.CertificateValidationMode = X509CertificateValidationMode.None;
            e.ServiceConfiguration = serviceConfiguration;
        }
