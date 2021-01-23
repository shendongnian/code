    XmlDocument xDoc = new XmlDocument();
    
    xDoc.LoadXml("<root><rates> <permanent votes = \"100\" > 6.54 </permanent>  <temprate votes = \"100\" > 6.54 </temprate></rates> </root> ");
    
    // find the nodes we are interested in
    XmlNode Rates = xDoc.SelectSingleNode("//rates");
    XmlNode Root = xDoc.SelectSingleNode("root");
    
    // We can't modify a collection live so create a temporary list
    List<XmlNode> TempList = new List<XmlNode>();
    
    foreach (XmlNode Node in Rates.ChildNodes)
    {
        TempList.Add(Node);          
    }
    
    // remove the nodes and their container node
    foreach (XmlNode Node in TempList)
    {
        Node.ParentNode.RemoveChild(Node);
    }
    // Use this to remove the parent and children
    // in one step
    // Rates.ParentNode.RemoveChild(Rates); 
    
    // insert in desired location
    foreach (XmlNode Node in TempList)
    {
        Root.AppendChild(Node);
    }
    
    // Hope this works!
    xDoc.Save("C:\\test.xml");
