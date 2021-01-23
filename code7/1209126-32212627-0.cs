    [DataContract(Namespace = "wcf", IsReference = true)]
    public class NewType : TypeFromLibrary
    {
        public NewType(TypeFromLibrary baseObj)
        {
            //set all props here
        }
        
        public event EventHandler<SomeEventArgs> SomeEvent;
        [OperationContract]
        public string SomeBaseFunction()
        {
        }
        [DataMember]
        public CustomBaseProp SomeProp { get; set; }
        [DataMember]
        public int SomeInt { get; set;}
    }
