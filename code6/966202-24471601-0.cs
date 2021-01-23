        public static class MyDateTimeChecker
        {
            public static bool CheckTime(this DateTime dt, int minutes)
            {
                if (dt.Day > dt.AddMinutes(minutes).Day)
                    return false;
                else
                    return true;
            }
        }
