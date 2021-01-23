     public class OutputCacheComplex : OutputCacheAttribute
        {
            public OutputCacheComplex(Type type)
            {
                PropertyInfo[] properties = type.GetProperties();
                VaryByParam = string.Join(";", properties.Select(p => p.Name).ToList());
                Duration = 3600;
            }
        }
