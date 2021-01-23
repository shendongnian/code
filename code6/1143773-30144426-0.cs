    public static class Helper
    {
        public static Type[] TypeArrayReturnerWithGeneric<T>()
        {
            return new Type[] { typeof(Expression<Func<T, object>>) };
        }
    }
