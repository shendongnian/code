    public static class Extensions
    {
        public static ABuilder With(this ABuilder builder, Action<ABuilder> action)
        {
            action(builder);
            return builder;
        }
  
        public static ABuilder ToBuilder(this A a)
        {
            return new ABuilder(a) { X = a.X };
        }
    }
