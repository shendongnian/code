        public static bool IsSymbol(String s, int index)
        {
            if (s==null)
                throw new ArgumentNullException("s");
            if (((uint)index)>=((uint)s.Length)) {
                throw new ArgumentOutOfRangeException("index");
            }
            Contract.EndContractBlock();
            if (IsLatin1(s[index])) {
                return (CheckSymbol(GetLatin1UnicodeCategory(s[index])));
            }
            return (CheckSymbol(CharUnicodeInfo.GetUnicodeCategory(s, index)));
        }
