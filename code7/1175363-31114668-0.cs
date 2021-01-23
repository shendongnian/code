    using System.Xml.XPath;
    using System.Xml.Linq;
    using System.IO;
    
    XDocument xdoc = XDocument.Load("test.xml");
    StringBuilder csv = new StringBuilder();
    
    foreach (XElement datarow in xdoc.Root.XPathSelectElements("dataset/datarow"))
    {
    	string knre1 = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("knre1")).First().Value;
    	string knre2 = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("knre2")).First().Value;
    	string betrag = datarow.Elements("element").Where(i => i.Attribute("id").Value.Contains("betrag")).First().Value;
    
    	csv.AppendLine(knre1 + "," + knre2 + "," + betrag);
    }
    
    File.WriteAllText("cvsFile.csv", csv.ToString());
