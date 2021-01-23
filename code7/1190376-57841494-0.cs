        // 2.3 - 0.3 = 2.0
        public static DateTime Floor(this DateTime value, TimeSpan interval) {
            var mod = value.Ticks % interval.Ticks;
            return value.AddTicks( -mod );
        }
        // 2.3 - 0.3 + 1 = 3.0
        public static DateTime Ceil(this DateTime value, TimeSpan interval) {
            var mod = value.Ticks % interval.Ticks;
            if (mod != 0) return value.AddTicks( -mod ).Add( interval );
            return value;
        }
