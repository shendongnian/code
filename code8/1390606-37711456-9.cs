        public static bool IsSymbol(char c)
        {
            if (IsLatin1(c)) {
                return (CheckSymbol(GetLatin1UnicodeCategory(c)));
            }
            return (CheckSymbol(CharUnicodeInfo.GetUnicodeCategory(c)));
        }
