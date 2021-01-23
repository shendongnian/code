    public static class Extensions
    {
        public static bool IsFlowerDescriptor(this object o)
        {
            return o is FlowerDescriptor;
        }
        public static Type GetFlowerDescriptor<T>(this FlowerDescriptor<T> o)
        {
            return typeof (T);
        }
    }
