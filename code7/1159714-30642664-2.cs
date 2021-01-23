    // create class instance
    InstViewModel model = new InstViewModel()
    {
        Uk = true,
        UkNrs = false,
    };
    
    // check it boolean fields
    foreach (var item in from property in typeof(InstViewModel).GetProperties()
                         let type = property.PropertyType
                         where type == typeof(bool) || type == typeof(bool?)
                         let value = property.GetValue(model)
                         select new { property, value })
    {
        Console.WriteLine("Model's {0} property is {1}", item.property.Name, item.value == null ? "(null)" : item.value);
    }
