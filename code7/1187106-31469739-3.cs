    class User
    {
        public int UserId { get; set; }
        
        public string UserName { get;set; }
        public List<Group> Groups { get; set; }
    }
    class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int GroupLevel { get; set; }
        public List<User> Users { get; set; }
    }
