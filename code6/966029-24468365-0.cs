    public SecurityContext()
        : base("DefaultConnection")
    {
        Database.SetInitializer<SecurityContext>(null);
    }
