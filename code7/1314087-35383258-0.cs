         namespace Portal.Services.ServiceContract
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPortalContract" in both code and config file together.
        [ServiceContract(Namespace = "")]
        public interface IPortalContract
        {
            [WebInvoke(ResponseFormat = WebMessageFormat.Json, Method = "GET", BodyStyle = WebMessageBodyStyle.Wrapped)]
            double Ping();
    
            [OperationContract]
            string CashInResult(string key);
        }
    }
