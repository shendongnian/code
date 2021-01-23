    public class User
    {
        public User(string id) { this.ID=id; }
        public string ID
        {
            get;
            private set;
        }
    }
    public interface IUserDto
    {
        public string UserID { get; }
        public void SetUser(User user);
    }
    public class UserOrderDto : IUserDto
    {
        public string UserID { get; private set; }
        public void SetUser(User user) { UserID=user.ID; }
        int OrderAmount { get; set; }
    }
    public class UserContactDto : IUserDto
    {
        public string UserID { get; private set; }
        public void SetUser(User user) { UserID=user.ID; }
        string PhoneNumber { get; set; }
    }
    class Program
    {
        internal static T Map<T>(User user) where T : IUserDto, new()
        {
            T map=new T();
            map.SetUser(user);
            return map;
        }
        static void Main(string[] args)
        {
            var user=new User("Mary");
            var map=Map<UserContactDto>(user);
        }
    }
