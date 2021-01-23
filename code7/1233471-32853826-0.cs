    XmlElement root = doc.DocumentElement;
    // Use XPath to find <ni> that contain CounterSales, rather than use string comparison
    XmlNodeList nodes = root.SelectNodes("//nd/ni[ns='CounterSales']");
    foreach (XmlNode node in nodes)
    {
        XmlNodeList nsNodes = node.SelectNodes("ns");
        // Get index of "CountersSales" within <ni>
        int index = 0;
        while (index < nsNodes.Count)
        {
            if (nsNodes[index].InnerText == "CounterSales")
                break;
            index++;
        }
        // Search through <nv>
        XmlNodeList nvNodes = node.SelectNodes("nv");
        foreach (XmlElement nvNode in nvNodes)
        {
            XmlNode nadNode = nvNode.SelectSingleNode("nad");
            // Get the stuff after the last equals sign. Possibly use regex here instead.
            string id = nadNode.InnerText.Substring(nadNode.InnerText.LastIndexOf('=') + 1);
            // XPathQuery for r element at our index (position in xpath is 1-based, rather than 0-based like C#)
            string rQuery = String.Format("r[position() = {0}]", index + 1);
            XmlNode rNode = nvNode.SelectSingleNode(rQuery);
            Console.WriteLine("{0}, {1}", id, rNode.InnerText);
        }
    }
