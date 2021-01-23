    public XElement GetValuePartnerByID(string rutaPart, string id, string node)
        {
            XDocument archivoXML = XDocument.Load(rutaPart);
            
            XElement valuePart = (from c in archivoXML.Elements("partners").Elements("partner")
                                     where c.Element("id").Value == id
                                     select c.Element(node)).FirstOrDefault();
            return valuePart;
        }
