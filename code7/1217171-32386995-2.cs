        public static DateTime? StrToDate(string val)
        {
            CultureInfo enUS = new CultureInfo("en-US");
            DateTime dateValue;
            if (DateTime.TryParseExact(val, "MM/dd/yyyy", enUS,
                                       DateTimeStyles.AllowWhiteSpaces, out dateValue))
            {
                return (dateValue);
            }
            else
            {
                return null;
            }
        }
