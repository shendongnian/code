    class User 
    { 
        public int Id { get; set; } 
        public UserRole Roles { get; set; } 
    }
    [Flags]
    public enum UserRole
    {
        Guest = 0,
        Worker = 1,
        Manager = 1 << 2,
        Director = 1 << 3,
    }
