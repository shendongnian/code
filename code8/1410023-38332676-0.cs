    public struct YourStruct
    {
    ...
        private long myTimeAsTicks;
        public DateTime MyTime { get { return new DateTime(myTimeAsTicks); } }
    ...
    }
