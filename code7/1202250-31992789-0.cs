    public class SecurityQuestion
    {
        public string Id { get; set; }
        public string Answer { get; set; }
        public string Hint { get; set; }
    }
    public class RequestObject
    {
        public string UserName { get; set; }
        public SecurityQuestion SecurityQuestion { get; set; }
    }
