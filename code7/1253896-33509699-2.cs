    public static IQueryable<MyData> FilterByParameters(this IQueryable<MyData>,Dictionary<string,string> dict)
    {
      IQueryable<Mydata> query=this;
      foreach(var entry in dict)
      {
         string val = String.Format(";{0}={1};",entry.Key,entry.Value);
         query=query.Where(a=>(";"+a.ParameterStr+";").Contains(val));
      }
      return query;
    }
    public static IQueryable<MyData> FilterByParameters(this IQueryable<MyData>,string s)
    {
      return this.FilterByParameters(GetParameters(s));
    }
    public static Dictionary<string,string> GetParameters(string s)
    {
      return s.Split(';')
        .Where(t=>t.Contains("="))
        .ToDictionary(t=>t.Split('=')[0].Trim,t=>t.Split('=')[1].Trim());
    }
