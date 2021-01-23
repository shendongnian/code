        public static IEnumerable<Pair<int>> WalkSplits(this string str, int startIndex, int count, params char[] separator)
        {
            if (string.IsNullOrEmpty(str))
                yield break;
            var length = str.Length;
            int endIndex;
            if (count < 0)
                endIndex = length;
            else
            {
                endIndex = startIndex + count;
                if (endIndex > length)
                    endIndex = length;
            }
            while (true)
            {
                int nextIndex = str.IndexOfAny(separator, startIndex, endIndex - startIndex);
                if (nextIndex == startIndex)
                {
                    startIndex = nextIndex + 1;
                }
                else if (nextIndex == -1)
                {
                    if (startIndex < endIndex)
                        yield return new Pair<int>(startIndex, endIndex - 1);
                    yield break;
                }
                else
                {
                    yield return new Pair<int>(startIndex, nextIndex - 1);
                    startIndex = nextIndex + 1;
                }
            }
        }
