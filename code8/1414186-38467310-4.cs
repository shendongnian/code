    public static class Helper {
        public static int NumberOfProperties(Type type)
        {
            return type.GetProperties().Count();
        }
    }
    
