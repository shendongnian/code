    public static IList<string[]> ToStringArray(this IQueryable queryFinal)
    {
      var query = (IQueryable<dynamic>)queryFinal;
      IList<dynamic> data = query.ToList();
      System.Reflection.PropertyInfo[] props = null;
      if (data.Count > 0) props = data[0].GetType().GetProperties();
      if (props == null) return new List<string[]>();
      /*I do other things using reflection here*/
      return data.Select(d => props.Select(p => (p.GetValue(d, null) ?? string.Empty).ToString()).OfType<string>().ToArray()).ToList();
    }
