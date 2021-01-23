    public class User
    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Salt { get; set; }
        public static implicit operator User(NotAnEntityUser o)
        {
            return new User { Id = o.Id, UserName = o.UserName, Salt = o.Salt };
        }
    }
    public class NotAnEntityUser
    {
        public virtual string Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Salt { get; set; }
    }
