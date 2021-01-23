    static void LoadXML()
    {
      string xml = "<?xml version=\"1.0\" ?><!DOCTYPE doc 
    	[<!ENTITY win SYSTEM \"file:///C:/Users/user/Documents/testdata2.txt\">]
    	><doc>&win;</doc>";
    
      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.XmlResolver = null;   // Setting this to NULL disables DTDs - Its NOT null by default.
      xmlDoc.LoadXml(xml);
      Console.WriteLine(xmlDoc.InnerText);
      Console.ReadLine();
    }
