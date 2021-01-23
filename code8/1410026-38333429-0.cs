    public struct BlittableDateTime
    {
        private BlittableDateTime(long ticks)
        {
            _ticks = ticks;
        }
        public static implicit operator BlittableDateTime(DateTime value)
        {
            return new BlittableDateTime(value.Ticks);
        }
        public static implicit operator DateTime(BlittableDateTime value)
        {
            return new DateTime(value._ticks);
        }
        
        private readonly long _ticks;
    }
