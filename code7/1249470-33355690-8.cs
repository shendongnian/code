    Public static class ListExtensions
     {
        Public static IEnumerable<dynamic> ToPivot(this List<Entity> oCollection)
        {
            List<dynamic> parent = new List<dynamic>();
            List<dynamic> extended = null;
        
            foreach (Entity entity in oCollection)
            {
                extended = new List<dynamic>();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    extended.Add(new { Property = prop.Name, Value = prop.GetValue(entity) });
                }
        
                parent.AddRange(extended);
            }
        
            // Grouping of value by property names, so each property
            // represents list of all values w.r.t to that property in given list.
            var grps = from d in parent
                       group d by d.Property
                           into grp
                           select new
                           {
                               Property = grp.Key,
                               Values = grp.Select(d2 => d2.Value).ToArray()
                           };
            return grps;
        }
    }
