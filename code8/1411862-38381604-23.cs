        [DataContract]
        public class TestSave : SerializeableObject
        {        
            [DataMember]
            public string objectName
            {
                get;
                set;
            }
    
            [DataMember]
            public bool SaveTestProp { get; set; }
    
            public DataContractSerializer GetSerializer()
            {
                return new DataContractSerializer(typeof(TestSave));
            }
        }
    
        public interface SerializeableObject
        {
            string objectName { get; }
            DataContractSerializer GetSerializer();
        }
