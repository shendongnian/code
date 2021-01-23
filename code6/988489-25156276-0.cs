    public class User
    {
        public string id, name, image;
    
        public User (IFBGraphUser user)
        {
            id = user.GetId ();
            name = user.GetName ();
            GetEmail ();
        }
        
        public Task<string> Email {
          get{
            return emailTask.Task;
          }
        }
    
        private TaskCompletionSource<string> emailTask =
             new TaskCompletionSource<string>();
    
        private void GetEmail()
        {
            FBRequestConnection.StartWithGraphPath ("/me", null, "GET", ConnectionReturn);
        }
    
        private void ConnectionReturn(FBRequestConnection connection, NSObject result, NSError error)
        {
            var me = (FBGraphObject)result;
            Console.WriteLine("this is a test");
            emailTask.SetResult(me["email"].ToString());
        }
    }
