    var projects = XDocument
        .Load(Server.MapPath("~/Content/abc.xml"))
        .Root
        .Elements("Project")
        .Select(p => new Project {
                    Id = (string) p.Element("Id"),
                    Name = (string) p.Element("Name")
                })
        .ToList();
                          
