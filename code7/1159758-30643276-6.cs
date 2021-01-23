    static class Ext
    {
        public static TOut MapTo<TIn, TOut>(this TIn obj, Func<TIn, TOut> func)
            where TIn : class
        {
            return obj == null
                ? default(TOut)
                : func(obj);
        }
        public static TOut If<TOut>(this object obj)
           where TOut : class
        {
           return obj as TOut;
        }
    }
