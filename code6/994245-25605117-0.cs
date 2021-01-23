    namespace MvcHtmlHelpers
    {
        public static class MvcHtmlHelpers
        {
            public static string ToString(this DateTime inputDate, bool FixTime)
            {
                if (FixTime)
                {
                    string returnString;
    
                    if (inputDate == DateTime.MinValue)
                    {
                        returnString = "N/A";
                    }
                    else
                    {
                        returnString = inputDate.ToShortDateString() + ' ' + inputDate.ToShortTimeString();
                    }
                    return returnString;
                }
                return inputDate.ToString();
            }
        }
    }
