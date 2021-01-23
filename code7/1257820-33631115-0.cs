      public class TestService : ITestService
      {
         public string FindUser(string userName, string password)
         {
            var user = Membership.GetUser(username, password);
            return (user!=null?user.userName: string.Empty);
         }
     }
