      public static DateTimeOffset UtcNow {
            get { 
                return new DateTimeOffset(DateTime.UtcNow);
            } 
      } 
      public DateTime DateTime { 
            get {
                return ClockDateTime;
            }
        } 
       private DateTime ClockDateTime { 
            get {
                return new DateTime((m_dateTime + Offset).Ticks, DateTimeKind.Unspecified); 
            }
        }
      public DateTime UtcDateTime { 
            [Pure] 
            get {
                Contract.Ensures(Contract.Result<DateTime>().Kind == DateTimeKind.Utc); 
                return DateTime.SpecifyKind(m_dateTime, DateTimeKind.Utc);
            }
        }
