    class UserIdentity
    {
        public static IDictionary<string, DateTime> OnlineUsers { get; }
    
        //This is a static initializer, which is called when the first reference to this class is made and can be used to initialize the statics of the class
        static UserIdentity()
        {
            OnlineUsers = new Dictionary<string, DateTime>();
        }
    }
 
