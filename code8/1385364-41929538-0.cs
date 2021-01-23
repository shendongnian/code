     //static class to convert milisecond to datetime    
    static class ConvertToDate
    {
        static readonly DateTime UnixEpochStart =
                DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc); //Coverting date in to universal 
        public static DateTime ToDateTimeFromEpoch(this long epochTime)
        {
            DateTime result = UnixEpochStart.AddMilliseconds(epochTime);
            return result;
        }
    
 
