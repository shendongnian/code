     settings.SslSettings = new SslSettings
            {
                ClientCertificates = new[] { cert },
                ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    foreach (var item in chain.ChainElements)
                    {
                        foreach (var elemStatus in item.ChainElementStatus)
                        {
                            Console.WriteLine( item.Certificate.Subject + "->" + elemStatus.StatusInformation);
                        }
                    }
                    
                    return true; //NOT FOR PRODUCTION: this line will bypass certificate errors.
                }
           }
