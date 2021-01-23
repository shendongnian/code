    var o = typeof(Product).GetProperties().Select(a => new
                {
                    PropertyName = a.Name,
                    Type = a.PropertyType.Name,
                    IsPrimitive = a.PropertyType != null && a.PropertyType.IsPrimitive
                }).ToList();
    var jsonString = JsonConvert.SerializeObject(o);
