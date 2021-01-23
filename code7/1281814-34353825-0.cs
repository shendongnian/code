    [DataContract(Name = "desc", Namespace = "")]
    public class Desc
    {
        [DataMember(Name = "l_error")]
        public LError LError { get; set; }
    }
    
    [CollectionDataContract(ItemName = "error", Namespace = "")]
    public class LError : List<string>
    {    
    }
