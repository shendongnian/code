     string text = "This is just a test ! test";
     var uniqueList = new List<string>();
     var items = text.Split(' ').Where(s => !uniqueList.Contains(s))
                                .Select(s=> { 
                                              uniqueList.Add(s);
                                              return s; 
                                            })
                                .ToList();
