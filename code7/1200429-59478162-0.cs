                    System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12;
                    ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };
