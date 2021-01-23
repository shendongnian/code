    public static string GuidCreator()
    {
        var bytes = Guid.NewGuid().ToByteArray();
        var builder = new StringBuilder();
        foreach (var aByte in bytes)
        {
            var nibble1 = Convert.ToChar((aByte & 0x0F) + 65);
            var nibble2 = Convert.ToChar(((aByte & 0xF0) >> 4) + 65);
            builder.Append(nibble1);
            builder.Append(nibble2);
        }
        return builder.ToString();
    }
