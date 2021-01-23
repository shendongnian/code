    DateTimeOffset dto = DateTimeOffset.Now;
    using (var w = new BinaryWriter(...))
    {
        w.Write(dto.Ticks);
        w.Write(dto.Offset.Ticks);
    }
    using (var r = new BinaryReader(...))
    {
        long ticks = r.ReadInt64();
        long offsetTicks = r.ReadInt64();
        dto = new DateTimeOffset(ticks, new TimeSpan(offsetTicks);
    }
