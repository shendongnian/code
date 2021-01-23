    public class Entity {
        public List<string> UserGUIDs { get; set; }
        [NotMapped]
        private List<UserPrincipal> _users;
        [NotMapped]
        public List<UserPrincipal> Users
        {
            get
            {
                if (_users != null)
                    _users = UserPrincipal.GetUsers(this.UserGUIDs);
                return _users;
            }
            set
            {
                this.UserGUIDs = value.Select(u => u.UserGUID).ToList();
                _users = value;
            }
        }
    }
