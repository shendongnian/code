    public static class Helper {
        // notice the type got changed from a generic <T>
        // to specifying the exact class you want to "extend"
        public static int NumberOfProperties(this MyBaseClass @this)
        {
            var type = typeof(T);
            return type.GetProperties().Count();
        }
    }
