    public class User
    {
       public int UserId { set;get;}
       public ICollection<Team> Teams { set; get; }
    }
    public class Sport
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public IEnumerable<Team> Teams { set; get; }
    }
    public class Team
    {
        public int TeamId { get; set; }
        public List<User> Users { get; set; }
        public int SportId { set; get; }
    }
