     public static class UserExtensions{
           public static void DoSomething(this Users.User user)
            {
                 var val = user.AddUser();
            }
     }
     //then you can do something like this:
     var u = new Users.User();
     u.DoSomething();
