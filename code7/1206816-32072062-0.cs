    public static class MyRegexps
    {
        public static readonly Regex PhoneNumber_Regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$");
        public static readonly Regex Email_Regex = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$.");
    }
