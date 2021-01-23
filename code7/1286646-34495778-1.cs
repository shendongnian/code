    XmlDocument xmlDoc = new XmlDocument();
    xmlDoc.LoadXml(xmlContent);
    
    XmlNodeList nodeList = xmlDoc.SelectNodes("{your-xpath-expression}");
    
    foreach (XmlNode node in nodeList)
    {
        // get existing 'BatteryTest' node
        XmlNode batteryNode = node.SelectSingleNode("BatteryTest.");
    
        // create new (renamed) Content node
        XmlNode newNode = xmlDoc.CreateElement(batteryNode.Name + node.Name);
    
        // [if needed] copy existing Content children
        //newNode.InnerXml = node.InnerXml;
    
        // replace existing BatteryTest node with newly renamed Content node
        node.InsertBefore(newNode, batteryNode);
        node.RemoveChild(batteryNode);
    }
