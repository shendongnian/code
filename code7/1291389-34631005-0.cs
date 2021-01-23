    public static class MonadExtensions
    {
        public static TResult With<TSource, TResult>(TSource source, Func<TSource, TResult> action) where TSource : class
            {
                if (source != default(TSource))
                    return action(source);
                return default(TResult);
            }
    }
