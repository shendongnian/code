    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, IncludeExceptionDetailInFaults = true)]
        public class SMTX_Service : ISMTX_Service
        {
        }
     private void StartService(Uri baseUri, string EndPointName, bool EnableServiceDiscovery)
            {
                    var serviceUri = new Uri(baseUri, EndPointName);
                    Host = new ServiceHost(typeof(WCF_TEST.SMTX_Service), baseUri);
                    Host.Faulted += h_ServiceFaulted;
                    Host.Opened += h_ServiceOpened;
                    Host.Closed += h_ServiceClosed;
                    WSHttpBinding wsHttpBinding = new WSHttpBinding();
                    wsHttpBinding.Security.Mode = SecurityMode.Message;
                    wsHttpBinding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.TripleDesSha256Rsa15;
                    wsHttpBinding.Security.Message.EstablishSecurityContext = true;
                    wsHttpBinding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
                    wsHttpBinding.Security.Message.NegotiateServiceCredential = true;
                    wsHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;
                    wsHttpBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;
                    wsHttpBinding.Security.Transport.Realm = "";
                    wsHttpBinding.MaxBufferPoolSize = 524288;
                    wsHttpBinding.MaxReceivedMessageSize = 4194304;
                    ServiceEndpoint SEP = Host.AddServiceEndpoint(typeof(WCF_TEST.ISMTX_Service), wsHttpBinding, EndPointName);
                    SEP.Name = EndPointName;
                    SEP.Address = new EndpointAddress(serviceUri);
                    SEP.Binding = wsHttpBinding;
                    ServiceMetadataBehavior SMB = new ServiceMetadataBehavior();
                    SMB.HttpGetEnabled = EnableServiceDiscovery;
                    Host.Description.Behaviors.Add(SMB);
                    ServiceCredentials SC = new ServiceCredentials();
                    SC.ServiceCertificate.Certificate = GetCertificate();
                    SC.ClientCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                    SC.UseIdentityConfiguration = false;
                    SC.ClientCertificate.Certificate = GetCertificate();
                    SC.WindowsAuthentication.AllowAnonymousLogons = false;
                    SC.WindowsAuthentication.IncludeWindowsGroups = true;
                    SC.Peer.PeerAuthentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                    Host.Description.Behaviors.Add(SC);
                    Host.Open();
            }
