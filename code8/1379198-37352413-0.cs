    [ServiceContract(Name = "MyContract", Namespace = "MyNameSpace")]
    public interface MyContract
    {
        [OperationContract, FaultContract(typeof(TDetail))]
        void ThrowException();
    }
    [DataContract(Name = "TDetail", Namespace = "MyNameSpace")]
    public class TDetail
    {
        public TDetail(string test)
        {
            Test = test;
        }
        [DataMember]
        public string Test { get; set; }
    }
