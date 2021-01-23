    public DateTime AddTicks(long value) 
    {
       long ticks = InternalTicks;
       return new DateTime((UInt64)(ticks + value) | InternalKind);
    }
