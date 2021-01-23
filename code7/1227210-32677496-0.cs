    var genCStatus = from id in Arb.Generate<int>()
                     from name in Arb.Generate<string>()
                     from isMatchable in Arb.Generate<bool>()
                     select new CStatus { Id = id, Name = name, IsMatchable = isMatchable };
    var genC = from status in genCStatus
               ...
               select new C { ... }
