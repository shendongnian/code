    enum Role
    {
        Unknown = 0,
        Patient = 1,
        Professional = 2
    }
    
    class Person
    {
        public IEnumerable<Role> Roles { get; private set; }
        public IdentityUser User { get; private set; }
    }
