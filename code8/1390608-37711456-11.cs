        public static bool IsSymbol(String s, int index)
        {
            // Removed for Brevity
            return (CheckSymbol(CharUnicodeInfo.GetUnicodeCategory(s, index)));
        }
