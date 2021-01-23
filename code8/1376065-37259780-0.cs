    var xDoc = new System.Xml.XmlDocument();
    xDoc.Load("myxml.xml");
    var xList = xDoc.SelectNodes("//Array/Cluster");//XmlNodeList
    foreach(XmlNode xNode in xList)
    {
       var xName = xNode.SelectSingleNode("Name");//XmlNode 
       string name = xNode.InnerText;
       // and so on
    }
