    // The special constructor is used to deserialize values.
    public Foo(SerializationInfo info, StreamingContext context)
    {
        // Reset the property value using the GetValue method.
        myProperty_value = (string) info.GetValue("props", typeof(string));
    }
