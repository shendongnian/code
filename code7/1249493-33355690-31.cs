    public static IEnumerable<dynamic> ToPivot<T>(this IList<T> oCollection)
    {
        var parent = new List<dynamic>();
        try
        {
            foreach (T entity in oCollection)
            {
                var extended = new List<dynamic>();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    extended.Add(new { Property = prop.Name, Value = prop.GetValue(entity) });
                }
                parent.AddRange(extended);
            }
            // Grouping of value by property names, so each property
            // represents list of all values w.r.t that property in given list.
            var grps = parent.GroupBy(d => d.Property).Select(grp => new
            {
                Property = grp.Key,
                Values = grp.Select(d2 => d2.Value).ToArray()
            });
            return grps;
        }
        catch
        {
            // log the reason perhaps
            return default(dynamic);
        }
    }
