    public static class StringExtensions
    {
        public static string[] ToSingleElementArray(this string inputString)
        {
            return new[] { inputString };
        }
    }
    private static string[] FooterContent()
    {
        return GetMyData().ToSingleElementArray();        
    }
