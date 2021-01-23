    public static class Extensions
    {
        public static T2 DisposeWrapper<T1, T2>(this T1 input, Func<T1,T2> function) where T1:IDisposable
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
