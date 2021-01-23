    public static class MiddleConsumer
    {
        public static MiddleConsumer<T> Create<T>( IConsumer<T> consumer ) where T : class, IBase
        {
            return new MiddleConsumer<T>( consumer );
        }
    }
