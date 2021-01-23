    public static class LazyStatic<T> where T : new()
    {
        private static T _static = new T();
        public static T Static
        {
           get
           {
              return _static;
           }
        }
    }
