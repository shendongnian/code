    public class ApiLanguages
    {
        // c# 6.0 syntax
        public static List<string> AllowedLanguages { get; set; } = new List<string>();
    
        public ApiLanguages()
        {
            // c# < 6.0 (old style) syntax
            AllowedLanguages = new List<string>();
    
            AllowedLanguages.Add("de");
        }
    }
