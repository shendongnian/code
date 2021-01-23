        string data = "\n<?xml version=\"1.0\" encoding=\"UTF-8\"?><element1 value=\"3\"><sub>1</sub></element1>\n<element1><sub><element>2</element></sub></element1>\n \n<element2><sub>3</sub></element2>\n \n<element2><sub>4</sub></element2>";
    
        //Clear whitespace and parse out the header
        data = data.Trim();
        var pos = data.IndexOf("?>") + 2;
        data = string.Concat("<root>",data.Substring(pos, data.Length - pos), "</root>");
        
        var xml = XDocument.Parse(data);
    
        //Nodes will have all the elements1, 2... etc.
        var nodes = xml.Descendants().Where(d => d.Name.LocalName.Contains("element"));
    
        //if you need to load to string list.
        var items = new List<string>();
        foreach(var node in nodes)
        {
            items.Add(node.ToString());
        }
