    public class User
    {
        private ICollection<Role> _roles;
        public virtual ICollection<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
            protected set { _roles = value; }
        }
        public IEnumerable<Role> ActiveRoles
        {
            get { return this.Roles.Where(u => !u.IsDeleted); }
        }
    }
