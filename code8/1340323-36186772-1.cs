    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId).GeneratedBy.Identity();
            Map(x => x.UserName);
            HasManyToMany(x => x.Roles)
               .Cascade.All()
               .Table("UserRoles");
        }
    }
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.RoleId).GeneratedBy.GuidComb();
            Map(x => x.Name);
            HasManyToMany(x => x.Users)
               .Cascade.All()
               .Inverse()
               .Table("UserRoles");
        }
    }
