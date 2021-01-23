    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Use the AddValue method to specify serialized values.
        info.AddValue("props", myProperty_value, typeof(string));
    }
