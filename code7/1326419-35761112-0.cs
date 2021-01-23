    public class User 
    {
     [Key] public int id { get; set; }     
     public int UserId { get; set; }
     public virtual User User{get;set;}
    }
    // ...
     modelBuilder.Entity<User>().HasOptional<User>(x=> x.User);
