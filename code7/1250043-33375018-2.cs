    public static class MyExtensions
    {
        public static T[] DeepClone<T>(this T[] source) where T : ICloneable
        {
            return source.Select(item => (T)item.Clone()).ToArray();
        }
    }
