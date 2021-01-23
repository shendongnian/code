    public static class ArrayExt
    {
        public static T[] Set<T>(this T[] self, int index, params T[] values)
        {
            Array.Copy(values, 0, self, index, values.Length);
            return self;
        }
    }
