    namespace System.Net.Http
    {
        public class WebRequestHandlerWithClientCertificates : WebRequestHandler 
        {
            private X509CertificateCollection clientCertificates;
            public override X509CertificateCollection ClientCertificates {
                get {
                    if (clientCertificates==null) {
                        clientCertificates = new X509CertificateCollection();
                    }
                    return clientCertificates;
                }
                set {
                    if (value==null) {
                        throw new ArgumentNullException("value");
                    }
                    clientCertificates = value;
                }
            }
			internal override HttpWebRequest CreateWebRequest (HttpRequestMessage request)
			{
				HttpWebRequest wr = base.CreateWebRequest (request);
            	wr.ClientCertificates.Add(ClientCertificates);
				return wr;
			}
        }
    }
