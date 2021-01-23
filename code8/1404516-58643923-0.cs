    Func<HttpMessageHandler> configureHandler = () =>
            {
                var bypassCertValidation = Configuration.GetValue<bool>("BypassRemoteCertificateValidation");
                var handler = new HttpClientHandler();
                //!DO NOT DO IT IN PRODUCTION!! GO AND CREATE VALID CERTIFICATE!
                if (bypassCertValidation)
                {
                    handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, x509Certificate2, x509Chain, sslPolicyErrors) =>
                    {
                        return true;
                    };
                }
                return handler;
            };
