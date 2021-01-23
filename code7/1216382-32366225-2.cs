    var dict = testList2
                .GroupBy(t2 => t2.Test1Id)
                .ToDictionary(
                    gr => gr.Key, 
                    gr => gr.ToList());
    testList1
        .Select(t1 => 
        { 
            t1.Test2Values = dict.ContainsKey(t1.Id) ? dict[t1.Id] : t1.Test2Values;
            return t1;
        })
        .ToList();
