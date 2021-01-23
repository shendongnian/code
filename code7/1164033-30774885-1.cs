    public override bool CanConvert(Type objectType)
    {
        return typeof(Person).IsAssignableFrom(objectType);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object value = Activator.CreateInstance(objectType);
        serializer.Populate(reader, value);
        Person p  = value as Person;
        if (p.Children != null)
        {
            foreach (Child child in p.Children)
            {
                child.Parent = p;
            }
        }
        return value;
    }
