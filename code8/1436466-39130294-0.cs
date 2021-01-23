        // Returns the date part of this DateTime. The resulting value
        // corresponds to this DateTime with the time-of-day part set to
        // zero (midnight).
        //
        public DateTime Date {
            get { 
                Int64 ticks = InternalTicks;
                return new DateTime((UInt64)(ticks - ticks % TicksPerDay) | InternalKind);
            }
        }
