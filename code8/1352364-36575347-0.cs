    public static class FluentExtensionMethods
    {
        public static Generic2DArrayAssertions<T> Should<T>(this T[,] actualValue)
        {
            return new Generic2DArrayAssertions<T>(actualValue);
        }
    }
