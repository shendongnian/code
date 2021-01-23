    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
                
                XDocument xdoc = XDocument.Load(XMLFile);
    
    var item = from items in xdoc.Element("EPICORTLOG").Descendants("POS")
                           where (string)items.Element("Id") == strSelectedPOSID
                           select items.Elements("TRADE").Elements("ITEM").ToList().ToList();
