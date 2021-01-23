    var result = Shopping.GroupBy(item => item.Name)
            .Select(group => new
            {
                Store = group.Key,
                Items = group.GroupBy(item => item.Code)
                             .Select(innerGroup => new
                             {
                                 Code = innerGroup.Key,
                                 Test1 = innerGroup.Where(item => item.Type == "Test1").Select(item => item.Value).ToList(),
                                 Test2 = innerGroup.Where(item => item.Type == "Test2").Select(item => item.Value).ToList(),
                             }).ToList()
            }).ToList();
