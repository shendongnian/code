    foreach (XmlNode p in listofProjests)
    {
        string id = p.SelectSingleNode("Id").InnerText;
        string name = p.SelectSingleNode("Name").InnerText;
        project.Add(new Project { Id = id, Name = name });
    }
