     public static string GetFormattedStringPadRight(this string val, int length, char charToPad)
        {
            string returnValue = string.Empty;
            if (!String.IsNullOrEmpty(val))
            {
                returnValue = val.ToString().PadRight((40 - val.Length), charToPad);
            }
            return returnValue;
        }
