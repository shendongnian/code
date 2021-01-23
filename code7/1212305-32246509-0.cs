    List<MyClass> result = xdoc.Root.Descendants("section")
                .Select(x => new MyClass
                   {
                       Name = (string)x.Attribute("name"),
                       ModelList = x.Elements("myModelClassXml")
                                    .Select(y => new SomeModelClass 
                        {
                            MyList1 = y.Elements("someValue")
                                       .Select(z => (string)z.Attribute("value")).ToList()
                                                                   }).ToList()
                        }).ToList();
