    public class SelectUserVM
    {
      public int SelectedUser { get; set; } // assumes User.Id is typeof int
      public IEnumerable<User> AllUsers { get; set; }
    }
