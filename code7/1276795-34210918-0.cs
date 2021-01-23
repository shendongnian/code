    public class CreateUserViewModel
    {
      public string UserName{set;get;}
      public string Password {set;get;}
      public int Age {set;get;}
    }
    public class Selection
    {
       public string Code {set;get;}
    }
    public class RegisterViewModel
    {
      public CreateUserViewModel User {set;get;}
      public List<Selection> Selections {set;get;}
    }
