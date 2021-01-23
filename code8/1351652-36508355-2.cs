    public class UserSettings
    {
      public int Id { get; set; }
      public int? UserId { get; set; }
   
      public virtual User User { get; set; }
    }
