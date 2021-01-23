    private static void DeleteXmlNode(string path, string tagname, string searchconditionAttributename, string searchconditionAttributevalue)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path); 
        XmlNodeList nodes = doc.GetElementsByTagName(tagname);\
       //XmlNodeList nodes = doc.GetElementsByTagName("user");
        foreach (XmlNode node in nodes)
        {
            foreach (XmlAttribute attribute in node.Attributes)
            {
                if ((attribute.Name == searchconditionAttributename) && (attribute.Value == searchconditionAttributevalue))
                //if ((attribute.Name == "name") && (attribute.Value == "aaa"))
                {
                    //delete.
                    node.RemoveAll();
                    break;
                }
            }
        }
        //save xml file.
        doc.Save(path);
    } 
