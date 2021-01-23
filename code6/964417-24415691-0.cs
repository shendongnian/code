    var list3 = list2.Concat(list1).GroupBy(p => p.name)
        .Select(g => new People{
            name= g.Key, 
            siblings = from p in g
                       from s in p.siblings
                       select s
        });
