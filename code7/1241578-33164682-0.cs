        public static bool TryParseExact(string str, out decimal result)
        {
            //  The regular decimal.TryParse() is a bit rubbish.  It'll happily accept strings which don't make sense, such as:
            //      123'345'6.78
            //      1''23'345'678
            //      123''345'678
            //
            //  This function does the same as TryParse(), but checks whether the number "makes sense", ie:
            //      - has exactly zero or one "decimal point" characters
            //      - if the string has thousand-separators, then are there exactly three digits inbetween them 
            // 
            //  Assumptions: if we're using thousand-separators, then there'll be just one "NumberGroupSizes" value.
            //
            //  Returns True if this is a valid number
            //          False if this isn't a valid number
            // 
            result = 0;
            if (str == null || string.IsNullOrWhiteSpace(str)) 
                return false;
            //  First, let's see if TryParse itself falls over, trying to parse the string.
            decimal val = 0;
            if (!decimal.TryParse(str, out val))
            {
                //  If the numeric string contains any letters, foreign characters, etc, the function will abort here.
                return false;
            }
            //  Note: we'll ONLY return TryParse's result *if* the rest of the validation succeeds.
            CultureInfo culture = CultureInfo.CurrentCulture;
            int[] expectedDigitLengths = culture.NumberFormat.NumberGroupSizes;         //  Usually a 1-element array:  { 3 }
            string decimalPoint = culture.NumberFormat.NumberDecimalSeparator;          //  Usually full-stop, but perhaps a comma in France.
            string thousands = culture.NumberFormat.NumberGroupSeparator;               //  Usually a comma, but can be apostrophe in European locations.
            int numberOfDecimalPoints = CountOccurrences(str, decimalPoint);
            if (numberOfDecimalPoints != 0 && numberOfDecimalPoints != 1)
            {
                //  You're only allowed either ONE or ZERO decimal point characters.  No more!
                return false;
            }
            int numberOfThousandDelimiters = CountOccurrences(str, thousands);
            if (numberOfThousandDelimiters == 0)
            {
                result = val;
                return true;
            }
            //  Okay, so this numeric-string DOES contain 1 or more thousand-seperator characters.
            //  Let's do some checks on the integer part of this numeric string  (eg "12,345,67.890" -> "12,345,67")
            if (numberOfDecimalPoints == 1)
            {
                int inx = str.IndexOf(decimalPoint);
                str = str.Substring(0, inx);
            }
            //  Split up our number-string into sections: "12,345,67" -> [ "12", "345", "67" ]
            string[] parts = str.Split(new string[] { thousands }, StringSplitOptions.None);
            if (parts.Length < 2)
            {
                //  If we're using thousand-separators, then we must have at least two parts (eg "1,234" contains two parts: "1" and "234")
                return false;
            }
            //  Note: the first section is allowed to be upto 3-chars long  (eg for "12,345,678", the "12" is perfectly valid)
            if (parts[0].Length == 0 || parts[0].Length > expectedDigitLengths[0])
            {
                //  This should catch errors like:
                //      ",234"
                //      "1234,567"
                //      "12345678,901"
                return false;
            }
            //  ... all subsequent sections MUST be 3-characters in length
            foreach (string oneSection in parts.Skip(1))
            {
                if (oneSection.Length != expectedDigitLengths[0])
                    return false;
            }
            result = val;
            return true;
        }
        public static int CountOccurrences(string str, string chr)
        {
            //  How many times does a particular string appear in a string ?
            //
            int count = str.Length - str.Replace(chr, "").Length;
            return count;
        }
