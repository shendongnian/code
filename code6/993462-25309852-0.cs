    using System.Runtime.Serialization;
    
    [DataContract]
    public class ConfigSettings
    {
        [DataMember]
        public string Setting1 { get; set; }
    
        [DataMember]
        public string Setting2 { get; set; }
    
        public ConfigSettings()
        { }
    }
