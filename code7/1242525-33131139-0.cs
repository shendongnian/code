    public enum Days
    {
        MON =1,
        TUE=2,
        WED=3,
        THUR=4,
        FRI=5,
        SAT=6,
        SUN=7
    }
    public static class EnumTypeExtensions
    {
        public static string FriendlyString(this Days day)
        {
            switch (day)
            {
                case Days.MON:
                    return "Monday";
    
