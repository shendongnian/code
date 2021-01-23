    public static class Factory
    {
        public static object Create(Type type)
        {
            return Activator.CreateInstance(type);
        }
    }
