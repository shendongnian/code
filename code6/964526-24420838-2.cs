    public class Entity {
        public string UserGUID { get; set; }
        [NotMapped]
        private UserPrincipal? _user;
        [NotMapped]
        public UserPrincipal User
        {
            get
            {
                if (!_user.HasValue)
                    _user = UserPrincipal.GetUser(this.UserGUID);  // Make this static for easier re-use.
                return _user.Value;
            }
            set
            {
                UserGUID = value.UserGUID;
                _user = value;
            }
        }
    }
