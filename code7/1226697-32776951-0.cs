    [Serializable]
    public class GetBulkBalanceRequest
    {
        // ....
        [XmlElement(Namespace = Constants.ServiceNamespace)]
        public String playerIDList;
    }
