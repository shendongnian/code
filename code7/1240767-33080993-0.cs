    public class User : Entity
    {
        ISet<UserRole> _roles = new HashSet<UserRole>();
        public virtual ISet<UserRole> Roles
        {
            get { return _roles }
        }
        ...
    }
