       public  UInt32 ToDosDateTime( DateTime dateTime)
        {
            DateTime startTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            TimeSpan currTime = dateTime - startTime;
            UInt32 time_t = Convert.ToUInt32(Math.Abs(currTime.TotalSeconds));
            return time_t;
        }
