    var document = XDocument.Load(@"d:\xml.xml");
    var list = document.Root
                       .Elements("file")
                       .Select((x, i) => new
                       {
                           Index = i,
                           Nodes = x.DescendantsAndSelf("file")
                                   .Select(y => new
                                   {
                                       Node = y,
                                       Path = string.Join("-", y.AncestorsAndSelf("file")
                                                    .Reverse()
                                                    .Select(f => f.Attribute("name").Value))
                                   })
                       }).ToList();
