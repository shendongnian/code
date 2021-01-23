    public static class DateTimeExtension
        {
            public static string ToStringExt(this DateTime p_Date, String format)
            {
                char[] separators = { ' ', '/', '-' };
    
                String stringDate = p_Date.ToString(format);
    
                foreach (char dateChar in format)
                {
                    if (stringDate.Contains(dateChar) && !separators.Contains(dateChar))
                    {
                        throw new FormatException("Format Error");
                    }
                }
                return stringDate;
            }
        }
