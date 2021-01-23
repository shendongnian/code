       [DataContract(Name = "MyResponse", Namespace = Common.Constants.ContractNamespace)]
    public class MyValidateModel
    {
        [DataMember]
        public MyResponse MyResponse { get; set; }
    }
