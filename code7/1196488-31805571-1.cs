    [Serializable]
    public class Element
    {
       [XmlElement("url")]
       public string Url { get; set; }
    
       [XmlElement("price")] 
       public string Price { get; set; }
    
       [XmlElement("manufacturer_warranty")]
       public string mw { get; set; }
    
       [XmlElement("country_of_origin")]
       public string co { get; set; }
       [XmlElement("language")]
       public string lg { get; set; }
       [XmlElement("binding")]
       public string bind { get; set; }
    }
