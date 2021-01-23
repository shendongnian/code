    public UserModelMap()
    {
        ...
        // here we go wrong - parent column cannot be same 
        HasManyToMany(x => x.UserRole).Table("UsersRoles")
            .ParentKeyColumn("RoleId")                     // parent column must target User
            .ChildKeyColumn("UserId")                      //   not Role
            ...
    public RoleModelMap()
    {
        ...
        HasManyToMany(x => x.UsersInRole).Table("UsersRoles")
            .ParentKeyColumn("RoleId")                     // parent column must target Role
            .ChildKeyColumn("UserId")                      //   here is correct
            ...
