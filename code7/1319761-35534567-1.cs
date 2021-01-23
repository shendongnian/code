        public static class StringFormatter
        {
            public static string DateFormat(this string value)
            {
                if (value == "")
                {
                    return "";
                }
                else
                {
                    return DateTime.Parse(value.ToString()).ToString("MM/dd/yyyy");
                }
            }
        }
