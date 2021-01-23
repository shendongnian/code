    public static class EmptyCarCreator
    {
        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
