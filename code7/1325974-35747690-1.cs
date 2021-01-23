    private static dynamic GetAnonymousObject(IEnumerable<string> columns, IEnumerable<object> values)
    {
       IDictionary<string, object> eo = new ExpandoObject() as IDictionary<string, object>;
       int i;
       for (i = 0; i < columns.Count(); i++)
       {
           eo.Add(columns.ElementAt<string>(i), values.ElementAt<object>(i));
       }
       return eo;
    }
