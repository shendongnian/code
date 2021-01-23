    public static class StrinExtensions
    {
        public static string[] ToArray(this string inputString)
        {
            return new[] { inputString };
        }
    }
    private static string[] FooterContent()
    {
        return GetMyData().ToArray();        
    }
