    public static List<BaseClass> GetAllItems()
    {
      using (var db = new MyDbEntities())
      {
        var q1 = db.InheritedClass1.Include("BaseClass").ToList()
           .ConvertAll(x => (BaseClass)InheritedClass1Mapper.MapFromContext(x));
        var q2 = db.InheritedClass2.Include("BaseClass").ToList()
           .ConvertAll(x => (BaseClass)InheritedClass2Mapper.MapFromContext(x));
    
        return q1.Union(q2).ToList();  
      }
    }
