        public IEnumerable<string> GetPartitionedStrings(string s)
        {
            if (s == null) yield break;
            
            if (s == "")
            {
                yield return "";
                yield break;
            }
            if (s.Length > 63) throw new ArgumentOutOfRangeException("String too long...");
            var arr = s.ToCharArray();
            for(ulong i = 0, maxI = 1UL << (s.Length - 1); i < maxI; i++)
            {
                yield return PutSpaces(arr, i);
            }
        }
        public string PutSpaces(char[] arr, ulong spacesPositions)
        {
            var sb = new StringBuilder(arr.Length * 2);
            sb.Append(arr[0]);
            ulong l = 1;
            for (int i = 1; i < arr.Length; i++, l <<= 1)
            {
                if ((spacesPositions & l) != 0UL) sb.Append(" ");
                sb.Append(arr[i]);
            }
            return sb.ToString();
        }
