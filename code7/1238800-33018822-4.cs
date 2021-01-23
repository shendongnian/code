      public class StoreHours {
        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
      }
    
      public class MergedStoreHours {
        public DayOfWeek FirstDayOfWeek { get; set; }
        public DayOfWeek LastDayOfWeek { get; set; }
        public TimeSpan OpenTime { get; set; }
        public TimeSpan CloseTime { get; set; }
    
        public override string ToString() {
          var day = FirstDayOfWeek != LastDayOfWeek ? FirstDayOfWeek + "-" + LastDayOfWeek : FirstDayOfWeek.ToString();
          var timeRange = OpenTime != CloseTime ? OpenTime + "-" + CloseTime : "-";
    
          return day + " " + timeRange;
        }
      }
