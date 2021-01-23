        public static bool IsSymbol(char c)
        {
            //Removed for Brevity
            return (CheckSymbol(CharUnicodeInfo.GetUnicodeCategory(c)));
        }
