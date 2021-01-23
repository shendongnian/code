    public class MyController: Controller
    {
        public Func<string> GetUserId; //For testing
        public MyController()
        {
            GetUserId = () => User.Identity.GetUserId();
        }
        //controller actions
    }
