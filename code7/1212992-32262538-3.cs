    public static class Extensions
    {
        public static TOut DisposeWrapper<TDisposable, TOut>(this TDisposable input, Func<TDisposable,TOut> function) where TDisposable:IDisposable
        {
            try
            {
                return function(input);
            }
            finally
            {
                input.Dispose();
            }
        }
    }
