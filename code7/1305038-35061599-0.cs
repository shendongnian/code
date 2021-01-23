    public class ApiLanguages
    {
        public static List<string> AllowedLanguages { get; set; }
    
        static ApiLanguages()
        {
            AllowedLanguages = new List<string>();
            AllowedLanguages.Add("de");
            //...
        }
    }
