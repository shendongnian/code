    public class User
    {
        public User()
        {
            discussionsIdList = new List<int>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int rank { get; set; }
        public List<int> discussionsIdList { get; set; }
    
    }
