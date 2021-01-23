      public class Head{
         public String Name {get;set;}
      
         public Config Config {get;set;}       
      
      }
      
      public class Config
      {       
          [XmlElement(ElementName="Section")]
          public Section[] Sections { get; set; }
      }
      
      public class Section
      {
          [XmlAttribute(AttributeName="name")]
          public String Name { get; set; }
      
      }
