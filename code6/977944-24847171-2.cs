    public class User
    {
      public User()
      {
        // Assign default options when user initialised
        Options = new UserOptions();
      }
      .... // properties of user (ID, Name etc.)
      public UserOptions Options { get; set; }
    }
