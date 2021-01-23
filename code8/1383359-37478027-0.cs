    public class UserProfile
    {
         public int Id { get; set; }
      
         public string FirstName { get; set; }
         public string LastName { get; set; }
         
         [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
         public string FullName { get; private set; }
    }
