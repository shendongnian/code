    [DataContract]
    [KnownType(typeof(Enumerate1))]
    [KnownType(typeof(Enumerate2))]
    [KnownType(typeof(EnumerateN))]
    // up yo 20
    public interface IEnumerate 
    {
        [DataMember]
        string Description{ get; set; }
        [DataMember]
        int ID {get; set;}
        //  whatever you need 
    }
----------
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Enumerator GetEnumerator(IEnumerate obj);
    }
