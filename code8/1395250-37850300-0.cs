        public partial class testDatas
    {
        public int duInDays
        {
            get 
            {
                TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
                DateTime indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, INDIAN_ZONE);
                return (indianTime - StartDate).TotalDays;
            }
        }
    }
