    public static class TextHelper
    {
        public static bool ContainsInterspersed(this string outer, string inner)
        {
            if (outer == null || inner == null)
                throw new ArgumentNullException();
            return ((IEnumerable<char>)inner).Aggregate(0, (nextIndex, ch) =>
                {
                    nextIndex = (nextIndex < 0 ? nextIndex : outer.IndexOf(ch, nextIndex));
                    if (nextIndex >= 0)
                        nextIndex++;
                    return nextIndex;
                }) >= 0;
        }
    }
