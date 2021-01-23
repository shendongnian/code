    public class User{
      public string Name { get; set; }  //simple property
      public virtual ICollection<Address> Addresses { get; set;} //normal navigation collection
      [NotMapped] public virtual Address CurrentAddress { get; set;} //We added this
    }
