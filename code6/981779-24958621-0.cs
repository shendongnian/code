    var props = from p in this.GetType().GetProperties()
                where typeof(Std).IsAssignableFrom( p.PropertyType ) ||
                      ( p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(List<>) && 
                        typeof(Std).IsAssignableFrom( p.PropertyType.GetGenericArguments()[0] ) )
                select new { Property = p };
