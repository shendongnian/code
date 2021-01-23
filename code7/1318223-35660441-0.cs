    public static class StringExtensions
    {
        public static void Find(this string source, string substring, StringComparison comparisonType, out int matchIndex, out int matchLength)
        {
            Find(source, substring, 0, source.Length, comparisonType, out matchIndex, out matchLength);
        }
        
        public static void Find(this string source, string substring, int searchIndex, StringComparison comparisonType, out int matchIndex, out int matchLength)
        {
            Find(source, substring, searchIndex, source.Length - searchIndex, comparisonType, out matchIndex, out matchLength);
        }
        
        public static void Find(this string source, string substring, int searchIndex, int searchLength, StringComparison comparisonType, out int matchIndex, out int matchLength)
        {
            matchIndex = source.IndexOf(substring, searchIndex, searchLength, comparisonType);
            if (matchIndex == -1)
            {
                matchLength = -1;
                return;
            }
            matchLength = FindMatchLength(source, substring, searchIndex, searchLength, comparisonType, matchIndex);
            
            // Defensive programming, but should never happen
            if (matchLength == -1)
                matchIndex = -1;
        }
        private static int FindMatchLength(string source, string substring, int searchIndex, int searchLength, StringComparison comparisonType, int matchIndex)
        {
            int matchLengthMaximum = searchLength - (matchIndex - searchIndex);
            int matchLengthInitial = Math.Min(substring.Length, matchLengthMaximum);
            // Hot path: match length is same as substring length.
            if (Compare(source, matchIndex, matchLengthInitial, substring, 0, substring.Length, comparisonType) == 0)
                return matchLengthInitial;
            int matchLengthDecrementing = matchLengthInitial - 1;
            int matchLengthIncrementing = matchLengthInitial + 1;
            while (matchLengthDecrementing >= 0 || matchLengthIncrementing <= matchLengthMaximum)
            {
                if (matchLengthDecrementing >= 0)
                {
                    if (Compare(source, matchIndex, matchLengthDecrementing, substring, 0, substring.Length, comparisonType) == 0)
                        return matchLengthDecrementing;
                    matchLengthDecrementing--;
                }
                if (matchLengthIncrementing <= matchLengthMaximum)
                {
                    if (Compare(source, matchIndex, matchLengthIncrementing, substring, 0, substring.Length, comparisonType) == 0)
                        return matchLengthIncrementing;
                    matchLengthIncrementing++;
                }
            }
            // Should never happen
            return -1;
        }
        private static int Compare(string strA, int indexA, int lengthA, string strB, int indexB, int lengthB, StringComparison comparisonType)
        {
            switch (comparisonType)
            {
                case StringComparison.CurrentCulture:
                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.None);
                case StringComparison.CurrentCultureIgnoreCase:
                    return CultureInfo.CurrentCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.IgnoreCase);
                case StringComparison.InvariantCulture:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.None);
                case StringComparison.InvariantCultureIgnoreCase:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.IgnoreCase);
                case StringComparison.Ordinal:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.Ordinal);
                case StringComparison.OrdinalIgnoreCase:
                    return CultureInfo.InvariantCulture.CompareInfo.Compare(strA, indexA, lengthA, strB, indexB, lengthB, CompareOptions.OrdinalIgnoreCase);
                default:
                    throw new ArgumentException("The string comparison type passed in is currently not supported.", nameof(comparisonType));
            }
        }
    }
