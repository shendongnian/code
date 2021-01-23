    public class Error
    {
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }
    
        public string Key { get; set; }
        public string Message { get; set; }
        // option 2 is with private setter but commented out
        /*public string Key { get; private set; }
        public string Message { get; private set; }*/
    }
