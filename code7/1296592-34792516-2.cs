    XmlDocument doc = new XmlDocument();
    doc.Load("Helikopter.config.xml");
    XmlNode node;
    node = doc.DocumentElement;
    // Iterate through all nodes
    foreach(XmlNode node1 in doc.ChildNodes)
    {
        // if the node is speler
        if(node1.Name == "speler")
        {
            // Change inner text to mens
            node1.InnerText = "mens";
        }
    }
    doc.Save("Helikopter.config.xml");
