    public interface IFoo
        {
        IBar MyBar { get; }
        String SomeInfo { get; }
        }
    public interface IBar
        {
        String SomeMoreInfo { get; }
        }
    
    [DataContract(Name = "Foo")]
    [KnownType(typeof(IFoo))]
    public class Foo : IFoo
        {
        private IBar _MyBar;
        private String _SomeInfo;
        [DataMember(Name = "MyBar")]
        public IBar MyBar
            {
            get { return _MyBar; }
            private set { _MyBar = value; }
            }
        [DataMember(Name = "SomeInfo")]
        public String SomeInfo
            {
            get { return _SomeInfo; }
            private set { _SomeInfo = value; }
            }
        }
    [DataContract(Name = "Bar")]
    [KnownType(typeof(IBar))]
    public class Bar : IBar
        {
        private String _SomeMoreInfo;
        [DataMember(Name = "SomeMoreInfo")]
        public String SomeMoreInfo
            {
            get { return _SomeMoreInfo; }
            private set { _SomeMoreInfo = value; }
            }
        }
    [ServiceContract]
    public interface IFooBarService
        {
        [OperationContract]
        [ServiceKnownType(typeof(Foo))]
        [ServiceKnownType(typeof(Bar))]
        bool SendFooBar(IFoo request);
        }
