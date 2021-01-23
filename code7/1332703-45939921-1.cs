    private string EPPLookupColorFixed(ExcelColor sourceColor)
        {
            var lookupColor = sourceColor.LookupColor();
            const int maxLookup = 63;
            bool isFromTable = (0 <= sourceColor.Indexed) && (maxLookup > sourceColor.Indexed);
            bool isFromRGB = (null != sourceColor.Rgb && 0 < sourceColor.Rgb.Length);
            if (isFromTable || isFromRGB)
                return lookupColor;
            // Ok, we know we entered the else block in EPP - the one 
            // that doesn't quite behave as expected.
            string shortString = "0000";
            switch (lookupColor.Length)
            {
                case 6:
                    // Of the form #FF000
                    shortString = lookupColor.Substring(3, 1).PadLeft(4, '0');
                    break;
                case 9:
                    // Of the form #FFAAAAAA
                    shortString = lookupColor.Substring(3, 2).PadLeft(4, '0');
                    break;
                case 12:
                    // Of the form #FF200200200
                    shortString = lookupColor.Substring(3, 3).PadLeft(4, '0');
                    break;
            }
            var actualValue = short.Parse(shortString, System.Globalization.NumberStyles.HexNumber);
            var percent = ((double)actualValue) / 0x200d;
            var byteValue = (byte)Math.Round(percent * 0xFF,0);
            var byteText = byteValue.ToString("X");
            byteText = byteText.Length == 2 ? byteText : byteText.PadLeft(2, '0');
            return $"{lookupColor.Substring(0, 3)}{byteText}{byteText}{byteText}";
        }
