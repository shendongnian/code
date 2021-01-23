    public UserModelMap()
    {
        ...
        // switch them
        HasManyToMany(x => x.UserRole).Table("UsersRoles")
            .ParentKeyColumn("UserId") // instead of("RoleId")
            .ChildKeyColumn("RoleId")  // instead of ("UserId")
            ...
    public RoleModelMap()
    {
        ...  // stays unchanged
        HasManyToMany(x => x.UsersInRole).Table("UsersRoles")
            .ParentKeyColumn("RoleId")
            .ChildKeyColumn("UserId")
            ...
