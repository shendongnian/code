    public class BaseEntity
    {
        public int Id { get; set; }
    }
    
    public class User : BaseEntity
    {
        public User(int id) : base()
        {
            this.Id = id;
        }
    
        public int UserId { get { return base.Id; } set { base.Id = value; } }
    }
