    static void Main(string[] args)
        {
            var o = typeof(Product).GetProperties().Select(a =>
                {
                    if (a.PropertyType != null && (a.PropertyType.IsPrimitive || a.PropertyType == typeof(string)))
                    {
                        return MapType(a);
                    }
                    else
                    {
                        dynamic p = null;
                        var t = MapType(a);
                        var props = a.PropertyType.GetProperties();
                        if (props != null)
                        { p = new { t, Properties = props.Select(MapType).ToList() }; }
                        return new { p.t.PropertyName, p.t.Type, p.t.IsPrimitive, p.Properties };
                    }
                }).ToList();
            var jsonString = JsonConvert.SerializeObject(o);
        }
        static dynamic MapType(PropertyInfo a)
        {
            return new
            {
                PropertyName = a.Name,
                Type = a.PropertyType.Name,
                IsPrimitive = a.PropertyType != null && a.PropertyType.IsPrimitive
            };
        }
