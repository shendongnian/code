    public class Aspnet_Role
    {
        public static readonly Aspnet_Role None = new Aspnet_Role(Roles.None, "None");
        public static readonly Aspnet_Role Admin = new Aspnet_Role(Roles.Admin, "Admin");
        public static readonly Aspnet_Role Moderator = new Aspnet_Role(Roles.Moderator, "Moderator");
        private Aspnet_Role(Roles role, string name)
        {
            Role = role;
            Name = name;
        }
        public enum Roles
        {
            None,
            Admin,
            Moderator
        }
        public Roles Role { get; set; }
        public string Name { get; set; }
        public Aspnet_Role Parse(Roles role)
        {
            switch(role)
            {
                case Roles.Moderator:
                    return Moderator;
                case Roles.Admin:
                    return Admin;
                case Roles.None:
                default:
                    return None;
            }
        }
        public bool IsUserInRole(Aspnet_Role role)
        {
            return Role == role.Role;
        }
        public override bool Equals(object obj)
        {
            if (obj is Aspnet_Role)
            {
                return Role == ((Aspnet_Role)obj).Role;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return Name;
        }
    }
