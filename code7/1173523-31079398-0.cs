    public partial class ListsSoapClient
    {
        protected override ListsSoap CreateChannel()
        {
    #if DEBUG
            //When debugging, change the binding's security mode
            //to match the endpoint address' scheme.
            if (this.Endpoint.Address.Uri.Scheme == "https")
                ((BasicHttpBinding)this.Endpoint.Binding).Security.Mode = BasicHttpSecurityMode.Transport;
            else
                ((BasicHttpBinding)this.Endpoint.Binding).Security.Mode = BasicHttpSecurityMode.None;
    #endif
            return base.CreateChannel();
        }  
    }
