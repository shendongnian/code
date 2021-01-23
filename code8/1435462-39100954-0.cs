        public const long    TicksPerMillisecond =  10000;
        private const double MillisecondsPerTick = 1.0 / TicksPerMillisecond;
 
        public const long TicksPerSecond = TicksPerMillisecond * 1000;   // 10,000,000
        private const double SecondsPerTick =  1.0 / TicksPerSecond;         // 0.0001
 
        public const long TicksPerMinute = TicksPerSecond * 60;         // 600,000,000
        private const double MinutesPerTick = 1.0 / TicksPerMinute; // 1.6666666666667e-9
 
        public const long TicksPerHour = TicksPerMinute * 60;        // 36,000,000,000
        private const double HoursPerTick = 1.0 / TicksPerHour; // 2.77777777777777778e-11
 
        public const long TicksPerDay = TicksPerHour * 24;          // 864,000,000,000
        private const double DaysPerTick = 1.0 / TicksPerDay; // 1.1574074074074074074e-12
