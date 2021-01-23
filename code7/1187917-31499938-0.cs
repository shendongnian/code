    public class User
    {
      public int Id { get; set; }
      public ICollection<User> Followers { get; set; }
      public ICollection<User> Following { get; set; }
    }
