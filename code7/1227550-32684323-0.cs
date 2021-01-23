    public static object shrink(this object source, params int[] mask)
    {
        var props = source.GetType().GetProperties();
        var values = mask
                    .Select((val, index) => new { val, index })
                    .Where(x => x.val != 0)
                    .Select(x => props[x.index])
                    .Select(prop => new { prop, value = prop.GetValue(source) })
                    .ToList();
    
        var type = Type.GetType("System.Tuple`" + values.Count)
                  .MakeGenericType(values.Select(x => x.prop.PropertyType).ToArray());
        var arguments = values.Select(x => x.value).ToArray();
        return Activator.CreateInstance(type, arguments);
    }
