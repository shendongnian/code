    List<NewClass> returnList = lookupList.ToList().Select(i => new NewClass {
                   Property1 = i.ID1.ToString(),
                   Property2 = i.ID2.ToString(),
                   Property3 = i.ID3.ToString(),
                   .....
                }).ToList();
