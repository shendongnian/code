    var s = new Settings()
    {
        Id = "id",
        Name = "name",
        ParentId = "parentId",
        Value = "value",
        SubSettings = new List<Settings>()
        {
            new Settings() 
            { 
                Id = "subId", 
                Name = "subName", 
                ParentId = "subParentId", 
                Value = "subValue", 
                SubSettings = new List<Settings>() 
            }
        }
    };
    
    XmlSerializer serializer = new XmlSerializer(typeof(Settings));
    
    string fileName = "C:\\test.xml";
    
    using (FileStream fs = File.Open(fileName, FileMode.CreateNew))
    {
        serializer.Serialize(fs, s);
    }
