    public static class ServiceClientFactory
    {
        public static HttpBindingBase BuildNavisionBinding(string endpointUrl)
        {
            //http://blog.randomdust.com/index.php/2010/10/could-not-establish-trust-relationship-for-the-ssl-tls-secure-channel/
            //http://www.codeproject.com/Forums/1649/Csharp.aspx?fid=1649&df=90&mpp=25&sort=Position&select=3126652&tid=3121885
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate
            {
                return true;
            });
            if (endpointUrl.ToLower().StartsWith("https"))
            {
                var binding = new BasicHttpsBinding(BasicHttpsSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                binding.MaxReceivedMessageSize = int.MaxValue - 1;
                return binding;
            }
            else
            {
                var binding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
                binding.MaxReceivedMessageSize = int.MaxValue - 1;
                return binding;
            }
        }
        public static TClient CreateClient<TClient, TChannel>(string endpoint, string username, string password)
            where TClient : ClientBase<TChannel>
            where TChannel : class
        {
            var client = (TClient)
                Activator.CreateInstance(
                    typeof (TClient),
                    BuildNavisionBinding(endpoint),
                    new EndpointAddress(endpoint));
            if (null == client.ClientCredentials)
                throw new Exception(
                    string.Format("Error initializing [{0}] client.  Client Credentials object was null",
                        typeof(TClient).Name));
            client.ClientCredentials.Windows.ClientCredential =
                new NetworkCredential(
                    username,
                    password);
            client.ClientCredentials.Windows.AllowedImpersonationLevel =
                TokenImpersonationLevel.Delegation;
            client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, 4, 0);
            client.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 4, 0);
            client.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 0, 4, 0);
            return client;
        }
