    public static class Helper {
        // notice the `this` keyword before the parameter 
        // this is what tells C# that this is an extension method
        public static int NumberOfProperties<T>(this T @this)
        {
            var type = typeof(T);
            return type.GetProperties().Count();
        }
    }
    
