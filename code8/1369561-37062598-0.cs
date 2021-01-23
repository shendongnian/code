    public class User
    {
       public int UserId { set;get;}
       public IEnumerable<Team> Teams { set;get;}
    }
    public class Team
    {
       public int TeamId { get; set; }
       public List<User> Members { get; set; }
       public int SportId { get; set; }
    }
