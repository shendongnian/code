     XmlDocument newdoc = new XmlDocument();
    newdoc.InnerXml = " <?xml version="1.0" encoding="utf-8" ?> 
    <Resorces>
    <Resource id="3" name="loreum ipsum" downloadcount="5"></Resource>
    <Resource id="2" name="loreum ipsum" downloadcount="9"></Resource>
    </Resorces>";
    List<string> list = new List <string>();
    var selectnode = "Resorces/Resource";
    var nodes = newdoc.SelectNodes(selectnode);
    foreach (XmlNode nod in nodes)
    {
        string id = nod["id"].InnerText;
        string name    = nod["name"].InnerText;
        string downloadcount = nod["downloadcount"].InnerText;       
        list.Add(id);
        list.Add(name);
        list.Add(downloadcount);
    }
    Console.WriteLine(list.Count);
