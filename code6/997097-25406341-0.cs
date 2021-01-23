    public class FrameSection
    {
       [XmlAttribute]
       public string Name { get; set; }
    
       [XmlIgnore]
       public string[] StartSection { get; set; }
    
       [XmlAttribute("StartSection")]
       public string StartSectionText
       {
          get { return String.Join(",", StartSection); }
          set { StartSection = value.Split(','); }
       }
    }
