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
            }).ToList();
        // now we need to add only unique items from this list to database 
        // one way to solve this problem is to create custom hashset and check if object's Name is there
        // this is also very fast as HashSet<T> lookup is almost O(1)
        HashSet<string> catNames = new HashSet<string>(db.Categories.Select(c => c.Name));
 
        db.Categories.AddRange(allCateogries.Where(c => !catNames.Contains(c.Name)));
    }
