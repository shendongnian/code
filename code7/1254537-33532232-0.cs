    private static ConcurrentDictionary<string, ActiveUser> ActiveUsers { get; set; }
    private class ActiveUser {
       public int ConnectionId { get; set; }
       public Dictionary<string, MyClass> MyClasses { get; set; } = new Dictionary<string, MyClass>();
    }   
    // . . . 
    Dictionary<string, ActiveUser> ActiveUsers = new Dictionary<string, ActiveUser>();
