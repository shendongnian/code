    public T Create<T>(IDictionary<string, object> propertyBag)
    {
        var result = (T)FormatterServices.GetUninitializedObject(typeof(T));
        foreach (var item in from member in typeof(T).GetMembers()
                             let dataMemberAttr = member.GetCustomAttributes(typeof(DataMemberAttribute), true).Cast<DataMemberAttribute>().SingleOrDefault()
                             where dataMemberAttr != null && propertyBag.ContainsKey(dataMemberAttr.Name)
                             select new { Member = member, Value = propertyBag[dataMemberAttr.Name] })
        {
            var property = item.Member as PropertyInfo;
            if (property != null)
            {
                property.SetValue(result, item.Value, null);
                continue;
            }
            var field = item.Member as FieldInfo;
            if (field != null)
            {
                field.SetValue(result, item.Value);
                continue;
            }
        }
        return result;
    }
