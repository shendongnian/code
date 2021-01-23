    using Microsoft.Web.Services3;
    using Microsoft.Web.Services3.Security;
    namespace WindowsFormsApplication1
    {
        class CustomSecurityServerInputFilter : ReceiveSecurityFilter
        {
            public override void ValidateMessageSecurity(SoapEnvelope envelope, Security security)
            {
                // do stuff
            }
            public CustomSecurityServerInputFilter(string serviceActor, bool isClient) : base(serviceActor, isClient)
            { }
        }
    }
