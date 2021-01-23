    public class User
    {
        private static Dictionary<string, string> _onlineUsers = new Dictionary<string, string>();
        public static void AddOnlineUser(string userId, string name)
        {
            _onlineUsers.Add(userId, name);
        }
        public static bool IsUserOnline(string userId)
        {
            return _onlineUsers.ContainsKey(userId);
        }
        public static string GetUser(string userId)
        {
            return _onlineUsers[userId];
        }
    }
    public class UserInfo
    {
        public string Id { get; set; }
        public bool IsOnline
        {
            get
            {
                return User.IsUserOnline(this.Id);
            }
        }
        public UserInfo(string id)
        {
            Id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User.AddOnlineUser("A101", "King");
            User.AddOnlineUser("A102", "Queen");
            User.AddOnlineUser("A103", "Jack");
            string[] ids = { "A101", "A103", "A104", "A105", "A102" };
            foreach (string id in ids)
            {
                var user = new UserInfo(id);
                string name = User.IsUserOnline(id) ? User.GetUser(id) : "N-" + id;
                string status = user.IsOnline ? "Online" : "Offline";
                Console.WriteLine(string.Format("User id: {0}.\nName: {1}.\nStatus: {2}", id, name, status));
                Console.WriteLine("_______________");
            }
        }
    }
