    SaveUser user = new SaveUser...; // create object
    
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", "http://www.mywebsite.no/webservice/types");
    ns.Add("i", "http://www.w3.org/2001/XMLSchema-instance");
    ns.Add("d2p1", "http://schemas.datacontract.org/2004/07/mywebsite.Engine.Engine.Types");
    
    XmlSerializer s = new XmlSerializer(typeof(SaveUser));
    StreamWriter w = new StreamWriter("Your XML File");
    s.Serialize(w, user, ns);
    w.Close();
