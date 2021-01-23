    public class User 
    {
      [Key]
      public int Id {get; set;}
      public string Name {get; set;}
      [ForeignKey("CityMappedToUser")]
      public string City_Name {get; set;}
      public virtual City CityMappedToUser{get; set;} 
    }
