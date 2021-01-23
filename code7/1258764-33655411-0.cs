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
