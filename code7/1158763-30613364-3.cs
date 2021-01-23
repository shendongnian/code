    List<website.Class1> a = objLibraryRef.GetFileLists1()
                             .Select(c => new website.Class1 {
                                       property1 = c.property1,
                                       ...
                                       propertyN = c.propertyN
                              }).ToList();
