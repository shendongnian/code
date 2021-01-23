      public DateTime TimeStamp
            {            
                get
                {
                    return DateTimeOffset.FromUnixTimeSeconds(int.Parse(_ts)).DateTime;
                }
            }
