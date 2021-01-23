    DateTime ukTime = new DateTime(2015, 9, 2, 17, 3, 0); // 2015-09-02 05:03 PM
    TimeZoneInfo UK_ZONE = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
    TimeZoneInfo INDIAN_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
    DateTime indianTime = TimeZoneInfo.ConvertTime(ukTime, UK_ZONE, INDIAN_ZONE);
    // 2015-09-02 09:33 PM
