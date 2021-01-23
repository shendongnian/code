    //Note, the following code is an outline of the general idea
    public static class RandomGenerator
    {
        private readonly static Lazy<Randomizer> inner = new Lazy<Randomizer>();
        public static IRandomizer Default { get { return inner.Value; } }
        
        public static IRandomizer CreateNew(Random seed)
        {
            return new Randomizer(seed);
        }
        private class Randomizer : IRandomizer
        {
            private readonly Random random;
            private readonly object syncLock = new object();
            public Randomizer(Random seed = null)
            {
                random = seed ?? new Random();
            }
            public int Next(int minValue, int maxValue)
            {
                lock (syncLock)
                {
                    return random.Next(minValue, maxValue);
                }
            }
        }
    }
