    var doc = XDocument.Load("your file");
    var result = doc.Root.DescendantsAndSelf("Element")
                         .Select(element => new 
                             { 
                                 Element = element.Attribute("name").Value, 
                                 Cars = element.Descendants("Car")
                                               .Select(car => new Car 
                                               { 
                                                   Id = car.Attribute("Id").Value, 
                                                   Color = car.Attribute("Color").Value 
                                               }).ToList() 
                         }).ToList();
