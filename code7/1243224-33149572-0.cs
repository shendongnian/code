    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member, memberSerialization);
        if (member is PropertyInfo)
        {
            var prop = (PropertyInfo)member;
            var isSensitiveData = Attribute.IsDefined(prop, typeof (SensitiveDataAttribute));
            if (isSensitiveData)
                property.ValueProvider = new StringValueProvider("SensitiveData");
        }
        return property;
    }
