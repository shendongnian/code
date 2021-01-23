    static IList<ExpandoObject> Read(DbDataReader reader) {
        var res= new List<Dictionary<string,object>>();
        foreach (var item in reader) {
            IDictionary<string,object> expando = new ExpandoObject();
            foreach (PropertyDescriptor propertyDescriptor in TypeDescriptor.GetProperties(item)) {
                var obj = propertyDescriptor.GetValue(item);
                expando.Add(propertyDescriptor.Name, obj);
            }
            res.Add(expando);
        }
        return res;
    }
