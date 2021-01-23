    public class DynamicCast<T> where T: class, new()
    {
        private Property[] _proprties;
        public DynamicCast()
        {
            _proprties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetSetMethod() != null)
                .Where(x => x.GetGetMethod() != null)
                .Select(p =>
                {
                    var property = new Property
                    {
                        PropertyInfo = p,
                        Name = p.Name
                    };
                    foreach (var attribute in p.GetCustomAttributes(false))
                    {
                        if (attribute.GetType() == typeof(JsonPropertyAttribute))
                        {
                            var jsonProperty = (JsonPropertyAttribute)attribute;
                            property.Name = jsonProperty.PropertyName;
                            break;
                        }
                        if (attribute.GetType() == typeof(JsonIgnoreAttribute))
                        {
                            return null;
                        }
                    }
                    return property;
                })
                .Where(p => p != null)
                .ToArray();
        }
        public T Cast(IDictionary<string, object> d)
        {
            var t = new T();
            Fill(d, t);
            return t;
        }
        public T Cast(JObject d)
        {
            var t = new T();
            Fill(d, t);
            return t;
        }
        public dynamic Cast(T t)
        {
            dynamic d = new ExpandoObject();
            Fill(t, d);
            return d;
        }
        public IEnumerable<T> Cast(IEnumerable<JObject> da)
        {
            return da.Select(e => Cast(e));
        }
        public IEnumerable<T> Cast(IEnumerable<object> da)
        {
            return da.Select(e =>
            {
                if (e is JObject) return Cast((JObject)e);
                if (e is IDictionary<string, object>) return Cast((IDictionary<string, object>)e);
                return null;
            });
        }
        public void Fill(IDictionary<string, object> values, T target)
        {
            foreach (var property in _proprties)
                if (values.TryGetValue(property.Name, out var value))
                    property.PropertyInfo.SetValue(target, value, null);
        }
        public void Fill(JObject values, T target)
        {
            foreach (var property in _proprties)
            {
                if (values.TryGetValue(property.Name, out var value))
                {
                    if (value is JValue jvalue)
                    {
                        var propertyValue = Convert.ChangeType(jvalue.Value, property.PropertyInfo.PropertyType);
                        property.PropertyInfo.SetValue(target, propertyValue, null);
                    }
                }
            }
        }
        public void Fill(T obj, IDictionary<string, object> target)
        {
            foreach (var property in _proprties)
                target[property.Name] = property.PropertyInfo.GetValue(obj, null);
        }
        private class Property
        {
            public PropertyInfo PropertyInfo;
            public string Name;
        }
    }
