    XElement xe = XElement.Load(Server.MapPath("your path"));
    
                var check = xe.Descendants("Destination")
                            .Where(n => n.Element("City").Value == "Ahmedabad")
                            .Select(l => l.Element("Top10PlacestoVisit"));
    
                List<someList> dst = new List<someList>();
              foreach (var item in check)
              {
                  var subs = item.Elements("details");
                  foreach(var item1 in subs)
                  {
                      dst.Add(new someList 
                      {
                          detail = item1.Value,
                          subtitle = item1.Attribute("subTitle").Value
    
                      });
                  }
              }
    
              ViewBag.all = dst;
