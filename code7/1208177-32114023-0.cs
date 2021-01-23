    [DataContract(Name = "Order", Namespace = "http://schemas.datacontract.org/2004/07/appulsive.MyCompany.SomeWebService")]
    public class Order
    {
        /// Various data members
        [DataMember]
        public string SomeStuff { get; set; }
    }
