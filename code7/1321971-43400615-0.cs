    class CustomHttpClient : DefaultHttpClient
        {
            private readonly System.Net.Security.RemoteCertificateValidationCallback _serverCertificateValidationCallback;
            public CustomHttpClient (System.Net.Security.RemoteCertificateValidationCallback serverCertificateValidationCallback) : base()
            {
                this._serverCertificateValidationCallback = serverCertificateValidationCallback;
            }
            protected override HttpMessageHandler CreateHandler()
            {
                var rv = base.CreateHandler() as WebRequestHandler;
                if (this._serverCertificateValidationCallback != null)
                    rv.ServerCertificateValidationCallback = this._serverCertificateValidationCallback;
                return rv;
            }
        }
