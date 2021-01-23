    public class LogicalSorter : IComparer<String>
    {
        public int Compare(String a, String b)
        {
            var aLength = a.Length;
            var bLength = b.Length;
            var aIdx = 0;
            var bIdx = 0;
            int aPartLen;
            int bPartLen;
            int aPartEndIndex;
            int bPartEndIndex;
            bool aIsString;
            bool bIsString;
            while (aIdx < aLength && bIdx < bLength)
            {
                if (char.IsDigit(a[aIdx]) && char.IsDigit(b[bIdx]))
                {
                    aPartEndIndex = aIdx;
                    while (aPartEndIndex < aLength && char.IsDigit(a[aPartEndIndex])) { aPartEndIndex++; }
                    
                    bPartEndIndex = bIdx;
                    while (bPartEndIndex < bLength && char.IsDigit(b[bPartEndIndex])) { bPartEndIndex++; }
                    aPartLen = aPartEndIndex - aIdx;
                    bPartLen = bPartEndIndex - bIdx;
                    if (aPartLen != bPartLen) return aPartLen < bPartLen ? -1 : 1;
                    while (aIdx < aPartEndIndex && a[aIdx] == b[bIdx])
                    {
                        aIdx++;
                        bIdx++;
                    }
                    if(aIdx != aPartEndIndex)
                        return a[aIdx] < b[bIdx] ? -1 : 1;
                }
                else
                {
                    aIsString = char.IsLetter(a[aIdx]);
                    bIsString = char.IsLetter(b[bIdx]);
                    if (aIsString != bIsString) return aIsString ? 1 : -1;
                    aPartEndIndex = aIdx;
                    while (aPartEndIndex < aLength && (char.IsLetter(a[aPartEndIndex]) == aIsString))
                    {
                        aPartEndIndex++;
                    }
                    bPartEndIndex = bIdx;
                    while (bPartEndIndex < bLength && (char.IsLetter(b[bPartEndIndex]) == bIsString))
                    {
                        bPartEndIndex++;
                    }
                    while (aIdx < aPartEndIndex && bIdx < bPartEndIndex && a[aIdx] == b[bIdx])
                    {
                        aIdx++;
                        bIdx++;
                    }
                    if ((aIdx != aPartEndIndex) || (bIdx != bPartEndIndex))
                        return a[aIdx] < b[bIdx] ? -1 : 1;
                }
            }
            return aLength < bLength ? -1 : 1;
        }
    }
