    public class UserAttribute
    {
        public string Id { get; set; }
        public string Value { get; set; }
    }       
    public class UserAttributes
    {
        public IList<UserAttribute> UserAttributes { get; set; }
    }
 
