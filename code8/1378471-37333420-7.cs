       [Pure]
        public static bool IsWhiteSpace(char c) {
                  
            if (IsLatin1(c)) {
                return (IsWhiteSpaceLatin1(c));
            }
            return CharUnicodeInfo.IsWhiteSpace(c);
        }
