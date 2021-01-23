        static TimeSpan _offset = new TimeSpan(0,0,0);
        public static TimeSpan CurrentOffset //Doesn't have to be public, it is for me because I'm presenting it on the UI for my information
        {
            get { return _offset; }
            private set { _offset = value; }
        }
        public static DateTime Now
        {
            get
            {
                return DateTime.Now - CurrentOffset;
            }
        }
        static void UpdateOffset(DateTime currentCorrectTime) //May need to be public if you're getting the correct time outside of this class
        {
            CurrentOffset = DateTime.UtcNow - currentCorrectTime;
            //Note that I'm getting network time which is in UTC, if you're getting local time use DateTime.Now instead of DateTime.UtcNow. 
        }
