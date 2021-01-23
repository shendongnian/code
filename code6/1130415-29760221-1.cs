    [XmlRoot(Namespace="http://test")]
    public class MainNode
    {
    	[XmlElement(Namespace="test3")]
    	public SubNode SubNode { get; set; }
    }
    
    public class SubNode
    {
    	public SettingsNode Settings { get; set; }
    }
    
    public class SettingsNode
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    
        [XmlAttribute("value")]
        public string Value { get; set; }
    }
