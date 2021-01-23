    string xml="Your XML String";
    XmlTextReader reader = new XmlTextReader(new System.IO.StringReader(xml));
        XmlDocument doc = new XmlDocument();
        XmlNode node = doc.ReadNode(reader);
          
        
        foreach (XmlNode chldNode in node.ChildNodes)
        {
            if (chldNode.HasChildNodes)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    string uniqueID = chldNode.Attributes["uniqueID"].Value;
                    Response.Write(employeeName + "<br />");
                }
            }
            
            
        }
