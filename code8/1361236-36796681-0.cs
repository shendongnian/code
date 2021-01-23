    using System.Linq;
    using System.Xml;
    using System.Xml.Linq;
    
    String GUID = "something";
    
    XElement profilesXel = XElement.Load("your xml file path");
    XElement currProfile = (from el in profilesXel
    						where (String)el.Element("GUID") == GUID
    						select el).First();
....
