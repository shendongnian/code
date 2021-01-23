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
            // Examine both strings on character level, keep track of where
            // we are in each string since lengths might differ
            while (aIdx < aLength && bIdx < bLength)
            {
                // If both strings contain digit at current index
                // compare numbers
                if (char.IsDigit(a[aIdx]) && char.IsDigit(b[bIdx]))
                {
                    // Get longest consecutive list of digits from each string
                    aPartEndIndex = aIdx;
                    while (aPartEndIndex < aLength && char.IsDigit(a[aPartEndIndex])) { aPartEndIndex++; }
                    
                    bPartEndIndex = bIdx;
                    while (bPartEndIndex < bLength && char.IsDigit(b[bPartEndIndex])) { bPartEndIndex++; }
                    aPartLen = aPartEndIndex - aIdx;
                    bPartLen = bPartEndIndex - bIdx;
                    // Compare lengths (longest number is greater)
                    if (aPartLen != bPartLen) return aPartLen < bPartLen ? -1 : 1;
                    // Same length numbers, compare chars until not same or end
                    while (aIdx < aPartEndIndex && a[aIdx] == b[bIdx])
                    {
                        aIdx++;
                        bIdx++;
                    }
                     
                    // If not at end compare last characters that were not same
                    if(aIdx != aPartEndIndex)
                        return a[aIdx] < b[bIdx] ? -1 : 1;
                }
                else
                {
                    // Comparing string vs number or string vs string
                    aIsString = char.IsLetter(a[aIdx]);
                    bIsString = char.IsLetter(b[bIdx]);
                    // if not 2 strings, number is always first
                    if (aIsString != bIsString) return aIsString ? 1 : -1;
                    // Get longest consecutive list of letters from each string
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
                    // Compare chars until not same or end
                    while (aIdx < aPartEndIndex && bIdx < bPartEndIndex && a[aIdx] == b[bIdx])
                    {
                        aIdx++;
                        bIdx++;
                    }
                    // if not at end compare last letters found
                    if ((aIdx != aPartEndIndex) || (bIdx != bPartEndIndex))
                        return a[aIdx] < b[bIdx] ? -1 : 1;
                }
            }
            // Use length as tie breaker
            return aLength < bLength ? -1 : 1;
        }
    }
