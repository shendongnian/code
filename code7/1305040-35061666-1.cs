    public class ApiLanguages
    {
        // c# 6.0 syntax
        public static List<string> AllowedLanguages { get; set; } = new List<string>();
    
        static ApiLanguages()
        {
            // c# < 6.0 (old style) syntax
            AllowedLanguages = new List<string>();
        }
        public ApiLanguages()
        {
            AllowedLanguages.Add("de");
        }
    }
