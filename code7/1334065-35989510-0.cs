    public void MyCustomTypes(string Xml)
    {
        XDocument xDoc = XDocument.Parse(Xml);
        var db = new MyContext();
    
        var caq1 = xDoc.Descendants().Where(e => e.Name.LocalName.Contains("FaceAdd")).Elements().Where(n => n.Name.LocalName.Contains("Buildingtype")).Select(v=>v.Value).Distinct().ToList();
    
        List<Category> allCateogries = caq1.Select(x => 
            new Category
            {
                 Name = x.ToString(),
                 NrOfFaceAdds= getNr(x.ToString(), xDoc)
            };
        ).ToList();
        // now we need to add this list to database 
        // we can use .Except only with custom IEqualityComparer<T>
        // this is because default comparer will check object hashcodes  
        // and we need to check custom properties.
        // one way to solve this problem is to create custom dictionary
        // and check if object's key (Name) is there
        // we'll use Name as key and NrOfFaceAdds as value
        // this is also very fast as dictionary use almost O(1) checks
        Dictionary<string, string> catDict = db.Categories.ToDictionary(c => c.Name, c => c.NrOfFaceAdds);  
     
        db.Categories.AddRange(allCateogries.Where(c => 
                     !catDict.ContainsKey(c.Name) || catDict[c.Name] != c.Value));
    }
