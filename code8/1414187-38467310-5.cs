    public static class Helper {
        // Notice the argument was removed and 
        // the use of the "generic" syntax <T>
        public static int NumberOfProperties<T>()
        {
            var type = typeof(T);
            return type.GetProperties().Count();
        }
    }
