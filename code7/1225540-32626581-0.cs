     var dataList =  db.SystemFamily.Where(x => x.SystemFamilyID == id.Value).SelectMany(s => s.Systems).GroupBy(key => key.SystemFamilyID, sys => new {sys},
                   (i, sys) =>
                   new SystemsViewModel{
                     System = sys,
                     Count = sys.Count()
                   }).ToList();
