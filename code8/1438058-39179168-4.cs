    public static class SystemTime
    {
        public static DateTime Now => MockedNow ?? DateTime.Now;
        public static DateTime UtcNow => MockedUtcNow ?? DateTime.UtcNow;
        public static DateTime Today => MockedToday ?? DateTime.Today;
        public static DateTime? MockedNow { get; set; }
        public static DateTime? MockedUtcNow { get; set; }
        public static DateTime? MockedToday { get; set; }
        public static void ResetMocks()
        {
            MockedNow = null;
            MockedToday = null;
            MockedUtcNow = null;
        }
    }
