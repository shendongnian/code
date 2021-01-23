    public static class ThridPArtyExtensionMethods
    {
        public static object LoadObject<T>(this T thirdParty, string param)
            where T : class
        {
            return param; // obviously not right
        }
        public static void DeleteObject<T>(this T thirdParty, string param)
            where T : class
        {
        }
        public static object UpdateObject<T>(this T thirdParty, string param)
            where T : class
        {
            return param; // obviously not right
        }
    }
