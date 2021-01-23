    public class ThreadsafeRandom : Random
    {
        private readonly object _lock = new object();
        public ThreadsafeRandom() : base() { }
        public ThreadsafeRandom( int Seed ) : base( Seed ) { }
        public override int Next()
        {
            lock ( _lock )
            {
                return base.Next();
            }
        }
        public override int Next( int maxValue )
        {
            lock ( _lock )
            {
                return base.Next( maxValue );
            }
        }
        public override int Next( int minValue, int maxValue )
        {
            lock ( _lock )
            {
                return base.Next( minValue, maxValue );
            }
        }
        public override void NextBytes( byte[ ] buffer )
        {
            lock ( _lock )
            {
                base.NextBytes( buffer );
            }
        }
        public override double NextDouble()
        {
            lock ( _lock )
            {
                return base.NextDouble();
            }
        }
    }
