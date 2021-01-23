    public static IEnumerable<object> ReadType(Type type)
    {
        return type.GetProperties().Select(a => new
        {
            PropertyName = a.Name,
            Type = a.PropertyType.Name,
            IsPrimitive = a.PropertyType.IsPrimitive && a.PropertyType != typeof (string),
            Properties = (a.PropertyType.IsPrimitive && a.PropertyType != typeof(string)) ? null : ReadType(a.PropertyType)
        }).ToList();
    }
    ...
    var result = ReadType(typeof(Product));
    json = JsonConvert.SerializeObject(result);
