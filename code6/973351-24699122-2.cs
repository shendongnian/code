        public static string SafeSmartSubstring(this string myString, int startIndex, int length)
        {
            var str = (myString ?? "").PadLeft(length);
            if (startIndex < 0)
            {
                startIndex = str.Length + startIndex;
            }
            return str.Substring(startIndex, length).Trim();
        }
