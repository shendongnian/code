    public class User
    {
        [Key]
        public Guid Id { get; set; }
    }
    
    public class Student
    {
        [Key]
        public int Id { get; set; }
    
        //Foreign key for User
        public Guid UserId { get; set; }
    
        public virtual User User { get; set; }
       
    }
