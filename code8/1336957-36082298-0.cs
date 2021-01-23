    public class WhiteListElement
    {
        public string CertLevel;
    
        public static WhiteListElement Create(XElement xml)
        {
            WhiteListElement element = new WhiteListElement();
            element.CertLevel = xml.Attribute("CERTLVL").Value;
            // Put data into object...
            return element;
        }
    }
    
    public class WhiteList
    {
        public List<WhiteListElement> Elements = new List<WhiteListElement>();
    
        public static WhiteList Create(string xmlUri)
        {
            WhiteList whiteList = new WhiteList();
            whiteList.Elements.AddRange(XElement.Load(xmlUri).Descendants("Kunder")
                .Where(xmlElement => xmlElement != null)
                .Select(xmlElement => WhiteListElement.Create(xmlElement)));
            return whiteList;
        }
    }
