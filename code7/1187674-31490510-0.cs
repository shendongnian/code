    public class MyRequiredAttribute : ValidationAttribute
    {
        private string httpVerb;
        public MyRequiredAttribute(string httpVerb)
        {
            this.httpVerb = httpVerb;
        }
        public override bool IsValid(object value)
        {
            if(HttpContext.Current.Request.HttpMethod == this.httpVerb)
            {
                return value != null;
            }
            return true;
        }
    }
    
    // Usage
    public class MyViewModel
    {
        [MyRequired("GET")]
        public string A { get; set; }
        
        [MyRequired("POST")]
        public string B { get; set; }
    }
