    [Flags]
    [TypeConverter(typeof(KeysConverter))]
    public enum Keys
    {
        ...
        A = 65,
        B = 66,
        C = 67,
        ...
        Shift = 65536,
        Control = 131072,
        Alt = 262144
    }
