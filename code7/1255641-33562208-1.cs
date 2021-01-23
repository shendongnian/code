        public static DateTime GetDateTimeFromString(string date)
        {
            string[] split = date.Split('-');
            int day = Convert.ToInt32(split[0]);
            int month = Convert.ToInt32(split[1]);
            int year = Convert.ToInt32(split[2]);
            return new DateTime(year, month, day);
        }
