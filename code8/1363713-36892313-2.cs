    var queryResult = (from a in calculate
                       join b in calculateData on a.Id equals b.CalcId into c
                       where a.SpecialID == 2023 && a.VersionId == 1
                       orderby a.InternalOrderNr ascending
                       select new
                       {
                            a.Field1,
                            a.Field2,
                            a.Field3,
                            myField4 = c.Select(d => new {
                                        d.Field1, d.Field2, 
                                        d.Field3, d.Field4
                                        d.Field5, d.Field6})
                        }).ToList();
    
    var result = new List<Storage>();
    foreach(var row in queryResult){
      var storage = new Strorage
      {
        myField1 = r.Field1,
        myField2 = r.Field2,
        myField3 = r.Field3,
        myField4 = new List<Tuple<int,int>>()
      };
      foreach(var subRow in row.myField4)
      {
        storage.myField4.Add(Tuple<int,int>(t.Field1, t.Field2));
        storage.myField4.Add(Tuple<int,int>(t.Field3, t.Field4));
        storage.myField4.Add(Tuple<int,int>(t.Field5, t.Field6));
      }
    }
    
    return result;
