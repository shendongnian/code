    public static class Scrub
    {
        public static T NotNull<T, U>(this T value, U property, string name)
        {
            if (property == null) throw new ArgumentNullException(name);
            return value;
        }
    }
