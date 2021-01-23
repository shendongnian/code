    public class CreateUserViewModel
    {
      public string UserName{set;get;}
      public string Location {set;get;}
      public int Age {set;get;}
    }
    public class RegisterViewModel
    {
      public CreateUserViewModel User {set;get;}
      public List<string> Selections {set;get;}
      public List<string> Grid {set;get;}
    }
