    public static class UserIdentity
    {
        public static IDictionary<string, DateTime> OnlineUsers { get; }
    
        static UserIdentity()
        {
            OnlineUsers = new Dictionary<string, DateTime>();
        }
    }
