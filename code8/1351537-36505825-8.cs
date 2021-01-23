    public class NavBarEntity
    {
       public NavBarEntity()
       {
          ID = Guid.NewGuid().ToString();
       }
       [Key]
       public string ID { get; set; }
       // Other properties/columns here
    } 
