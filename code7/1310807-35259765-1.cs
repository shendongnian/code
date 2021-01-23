    using System.Runtime.Serialization;
    
    namespace XMLConfigurationExample
    {
        [DataContract]
        public class Setting
        {
            [DataMember]
            public string Key { get; set; }
            [DataMember]
            public object Value { get; set; }
        }
    }
