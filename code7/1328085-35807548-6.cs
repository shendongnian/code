    public static List<object> GetInStudents(XDocument sourceXmlDoc)
    {
        IEnumerable<XElement> inStudentsElements = 
        sourceXmlDoc.Root.Elements("Classes").Descendants("Class")
                         .Descendants("Students").Descendants("Student");
        return inStudentsElements.Select(i => 
            new { Id = i.Elements().First().Value, 
                Name = i.Elements().Last().Value }).Cast<object>().ToList();
    }
    public static List<object> GetOutStudents(XmlDocument targetXmlDoc)
    {
        XmlNodeList outStudentsElements = targetXmlDoc.GetElementsByTagName("Students")[0].ChildNodes;
        var outStudentsList = new List<object>();
        for (int i = 0; i < outStudentsElements.Count; i++)
        {
            outStudentsList.Add(new { Id = outStudentsElements[i].ChildNodes[0].InnerText, 
                                      Name = outStudentsElements[i].ChildNodes[1].InnerText });
        }
        return outStudentsList;
    }
