    [DataContract]
    public class Test
    {
        [DataMember(Name = "values")]
        public TestValues values;
        
    }
    
    [CollectionDataContract(ItemName = "String")]
    public class TestValues : List<string> { }
