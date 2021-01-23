     class User
     {
        IRolesProvider roles;
        public User(IRolesProvider roles,....)
        {
            this.roles = roles;
            ...
        }
      
        public List<Roles> { get { return roles.GetRolesForUser(this);}}
        ...
     }
