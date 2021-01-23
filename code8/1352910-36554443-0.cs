    public class Member : Entity
    {
        public void Member()
        {
           Teams = new List<Team>();
        }
    
        public List<Team> Teams { get; set; }
