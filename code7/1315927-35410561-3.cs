    SaveUser user = new SaveUser...; // create SaveUser object
    user.User = new User1...; //create User1 object
    // **EDIT**: instantiate and add your namespace to User1 here...
    user.User.xmlns = new XmlSerializerNamespaces();
    user.User.xmlns.Add("d2p1", "http://schemas.datacontract.org/2004/07/mywebsite.Engine.Engine.Types");
    
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", "http://www.mywebsite.no/webservice/types");
    ns.Add("i", "http://www.w3.org/2001/XMLSchema-instance");
    
    XmlSerializer s = new XmlSerializer(typeof(SaveUser));
    StreamWriter w = new StreamWriter("Your XML File");
    s.Serialize(w, user, ns);
    w.Close();
