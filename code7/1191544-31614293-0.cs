    public static class Login{
     public static User LoggedUser {get; private set;}
     public static bool Authenticate(string userName, string password){
       //(a)Logic to fetch data based on username and pwd. mostly i use  Entityframework
       var user=context.Users.Find(x=>x.Name=userName && x.Pwd=MethodHelper.Decrypt(password));
       LoggedUser=user
       return LoggedUser != null;
     }
    }
