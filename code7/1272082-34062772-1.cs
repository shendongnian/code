                List<OtherObject> oList = new List<OtherObject>();
                oList.Add(new OtherObject() { Id = 2, Name = "First" });
                oList.Add(new OtherObject() { Id = 3, Name = "Second" });
    
                // each name with objects
                List<ObjectName> oNames = new List<ObjectName>();
                oNames.AddRange(oList.Select(p => new ObjectName() { 
                       Name = p.Name
                       , OtherObjectProperties = oList.Where(p1 => p1.Name == p.Name).ToList()
                }).Distinct()
                );
    
                // parent object with with object names
                MyObjects mo = new MyObjects() { Active = true, OtherObjects = oNames };
                
