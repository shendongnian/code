        using System;
        using System.ServiceModel.Web;
        private WebServiceHost webHost;
        public void Start()
        {
            webHost.Opening += ConfigureEnpointBinding;
            webHost.Open();
        }
        private void ConfigureEnpointBinding(object sender, EventArgs e)
        {
            var endpointBinding = (System.ServiceModel.WebHttpBinding)
                ((WebServiceHost)sender)
                .Description
                .Endpoints
                .Single(endpoint => endpoint.Contract.ContractType == typeof(IYourInterface))
                .Binding;
            endpointBinding.MaxReceivedMessageSize = int.MaxValue;
            endpointBinding.MaxBufferSize = int.MaxValue;
        }
