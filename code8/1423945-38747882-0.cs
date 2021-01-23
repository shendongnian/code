    XmlNodeList xnUnitList = xml.SelectNodes("/Units/Unit");
    foreach (XmlNode xn in xnUnitList)
    {
        string UNIT_NAME = xn["UNIT_NAME"].InnerText;
        listBox1.Items.Add(UNIT_NAME);
    
        // select all Nodes under the current Node 
        // that are a child of SRC
        // and have a name of SRC_NAME
        XmlNodeList SRC =xn.SelectNodes("SRC/SRC_NAME");
        foreach (XmlNode node in SRC)
        {
            // node is now a SRC_NAME so no further 
            // juggling needed, you have what you need
            string SRC_NAME = node.InnerText;
            listBox1.Items.Add(UNIT_NAME+"--" +SRC_NAME);
        }
    }
