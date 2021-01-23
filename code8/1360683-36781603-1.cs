    public class ValidationError
    {
        public List<string> reasons { get; set; }
    }
    
    public class RootObject
    {
        public string message { get; set; }
        public Dictionary<string, ValidationError> validationErrors { get; set; }
    }
