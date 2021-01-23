    var items = System.IO.Directory.GetFiles(@"path", "*.xml")
                         .Select(file => new
                         {
                             FileName = file, 
                             Item = System.Xml.Linq.XElement.Load(file)
                         })
                         .OrderBy(x => x.Item.Element("author").Attribute("sortby").Value)
                         .Select(x=>x.FileName) /*or .Select(x=>x.Item)*/
                         .ToList();
