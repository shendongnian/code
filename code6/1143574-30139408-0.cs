                var keyMap = weekDayMap.GroupBy(c => new {c.OpenFrom, c.OpenTo});
                var openingDay = new OpeningHourMapper();
                var period = new List<Period>();
                foreach (var put in keyMap )
                {
                    openingDay = weekDayMap.FirstOrDefault(c => c.OpenFrom == put.Key.OpenFrom && c.OpenTo == put.Key.OpenTo);
                    period.AddRange(GetPeriodList(openingDay, openingDay));
                }
    namespace Controllers.V1.Response.OpeningHourMapper
    {
        public class OpeningHourMapper
        {
            public int StationNumber { get; set; }
    
            public string Weekday { get; set; }
    
            public int WeekdayNumber { get; set; }
    
            public string OpenFrom { get; set; }
    
            public string OpenTo { get; set; }
        }
    }
