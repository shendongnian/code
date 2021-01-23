    foreach (XmlElement p in listofProjests)
    {
        string id = p["Id"].InnerText;
        string name = p["Name"].InnerText;
        project.Add(new Project { Id = id, Name = name });
    }
