    public static class Extensions
    {
        public static TOut DisposeWrapper<TDisposable, TOut>(this TDisposable input, Func<TDisposable,TOut> function) where TDisposable:IDisposable
        {
            using (input) return function(input);
        }
    }
