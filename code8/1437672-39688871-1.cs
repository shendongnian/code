    [XmlRoot("UserData")]
    public class UserDataContainer
    {
        public UserDataContainer() {...}
        // Can be used load and save a list of strings (Field(s) in XML)
        [XmlArray("Data"), XmlArrayItem("Field"),Type = typeof(string))]
        public List<string> Data = new List<string>();
        
        public static UserDataContainer Load(path){...}
        
        public void Save(path){...}
        public List<string> GetFields(){...}
        
        public void SetFields(List<string> Fields){...}
    }
 
