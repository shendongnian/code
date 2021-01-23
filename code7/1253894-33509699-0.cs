    public static IQueryable<MyData> FilterByParameters(this IQueryable<MyData>,Dictionary<string,string> dict)
    {
      IQueryable<Mydata> query=this;
      foreach(var entry in dict)
      {
         string val = entry.Key+"="+entry;
         query=query.Where(a=>(";"+a.field+";").Contains(val));
      }
      return query;
    }
    public static IQueryable<MyData> FilterByParameters(this IQueryable<MyData>,string s)
    {
      return this.FilterByParameters(GetParameters(s));
    }
