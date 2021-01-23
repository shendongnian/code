    protected Test(SerializationInfo info, StreamingContext context)
    {
        // Here _dict.Count == 0
        // So it found a Dictionary but no content?
        _dict = (Dictionary<string, int>)info.GetValue("foo", typeof(Dictionary<string, int>));
        _dict.OnDeserialization(null);
        // Content is restored.
        Console.WriteLine("_dict.Count={0}", _dict.Count);
    }
