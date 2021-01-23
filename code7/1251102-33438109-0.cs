        private void btnSend_Click(object sender, EventArgs e)
        {
            using (this.client = new HttpClient(this.InitialiseHandler()))
            {
                this.SetupRequest();
                this.SendRequest();
                this.RenderResponse();
            }
        }
        private WebRequestHandler InitialiseHandler()
        {
            var handler = new WebRequestHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                UseProxy = false,
            };
            var clientCert = this.GetClientCertificate();
            handler.ClientCertificates.Add(clientCert);
            handler.ServerCertificateValidationCallback += this.ValidationCallback;
            return handler;
        }
