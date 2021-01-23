    public class BaseEntity
    {
        public int Id { get; set; }
        public BaseEntity(int id)
        {
           Id = id;
        }
    }
    
    public class User : BaseEntity
    {
        public User(int id) : base(id)
        {
            UserId = id;
        }
    
        public int UserId { get; set; }
    }
