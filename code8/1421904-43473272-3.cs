    using (var r = new BinaryReader(...))
    {
        long utcTicks = r.ReadInt64();
        dto = new DateTimeOffset(utcTicks, TimeSpan.Zero).ToLocalTime();
    }
