    public static long ToUnixTimeMilliseconds(this Instant instant)
    {
        return instant.Ticks / NodaConstants.TicksPerMillisecond;
    }
    
