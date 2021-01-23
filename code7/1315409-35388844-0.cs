        public class UserAccount : IEqualityComparer<UserAccount>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool Equals(UserAccount x, UserAccount y)
            {
                return (x.UserName == y.UserName && x.Password == y.Password);
            }
            public int GetHashCode(UserAccount obj)
            {
                return obj.UserName.GetHashCode() + obj.Password.GetHashCode();
            }
        }
