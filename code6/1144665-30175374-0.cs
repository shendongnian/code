    public static class SpliceExtension
    {
        public static List<T> Splice<T>(this List<T> list, int offset, int count)
        {
            return list.Skip(offset).Take(count).ToList();
        }
    }
