    [WebService(Namespace = Constants.ServiceNamespace)]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        [SoapDocumentMethod(ParameterStyle = SoapParameterStyle.Bare, Action = "GetBulkBalance")]
        [return: XmlElement(ElementName = "GetBulkBalanceResponse")]
        public GetBulkBalanceResponse GetBulkBalance(GetBulkBalanceRequest getBulkBalanceRequest)
        {
            Int64 [] ids = getBulkBalanceRequest.playerIDList
                                .Split(',')
                                .Select(s => Int64.Parse(s)).ToArray();
            return new GetBulkBalanceResponse { responseValue = "response42" };
        }
    }
