    public TimeSpan Subtract(DateTime value) {
            return new TimeSpan(InternalTicks - value.InternalTicks);
        }
    
    public DateTime Subtract(TimeSpan value) {
        long ticks = InternalTicks;            
        long valueTicks = value._ticks;
        if (ticks - MinTicks < valueTicks || ticks - MaxTicks > valueTicks) {
            throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_DateArithmetic"));
        }
        return new DateTime((UInt64)(ticks - valueTicks) | InternalKind);
    }
