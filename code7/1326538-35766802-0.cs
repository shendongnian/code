    public class Entry
    {
         [XmlElement("term")]
         public string Term { get; set; }            
    
         [XmlElement("synonim")]
         public Term[] Synonym { get; set; }
    }
