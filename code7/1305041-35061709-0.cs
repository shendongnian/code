    public class ApiLanguages
    {
        private static IEnumerable<string> _allowedLanguages;
        public static IEnumerable<string> AllowedLanguages
        {
           get
           {
               return _allowedLangues ?? (_allowedLangues = new List<string>{ "EN", "AR"});
           }
        }    
    }
