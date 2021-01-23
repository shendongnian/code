    public class User : IEqualityComparer<User>
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public bool Equals(User x, User y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.ID.Equals(y.ID) &&
                   x.Email.Equals(y.Email);
        }
        public int GetHashCode(User obj)
        {
            return new { obj.ID, obj.Email }.GetHashCode();
        }
    }
