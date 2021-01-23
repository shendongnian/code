        public class LogInResult
    {
        public string Name { get; set; }
        public string cityName { get; set; }
        public string img { get; set; }
        public string usrId { get; set; }
    }
    
    public class RootObject
    {
        public List<LogInResult> logInResult { get; set; }
    }
