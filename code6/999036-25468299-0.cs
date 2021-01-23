      public interface IRegister
      {
    //Register related function
      }
      public interface ILogin
      {
    //Login related function
      }
      //UserRegister.cs file
     public partial classUser : IRegister, ILogin
      {
    //implements IRegister interface
      } 
     //UserLogin.cs file
     public partial classUser
     {
    //implements ILogin interface
     }
