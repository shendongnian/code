    public class EntityVoorbeeld : DbContext
    {
       public DbSet<Student> Students { get; set; }     
       /* 
          ... the rest of your context's properties and methods ...
       */
    }
