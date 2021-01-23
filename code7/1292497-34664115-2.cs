    public class CreateUser
    {
      [Required]
      public string Name {set;get;}
      [Required]
      public string Email {set;get;}
     
      public virtual string City { set; get; }
    }
    public class CreateUserWithAddress : CreateUser
    {
      [Required]
      public string AddressLine1 {set;get;}
      public string AddressLine12 {set;get;}
      [Required]
      public override string City { set; get; }  // make city required
    }
