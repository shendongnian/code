    public sealed class Status : StringIntegerEnum<Status>
    {
        public static readonly Status Active = new Status("active", 1);
        public static readonly Status Inactive = new Status("inactive", 0);
    
        private Status(string status, int statusCode) : base(status, statusCode) {}
    }
