    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplication1.Global.AllActiveUsers = new List<string>() { "test1", "test2" };
            UserFactory.GetUsersDetails();
        }
    }
    public static class UserFactory
    {
        public static List<string> GetUsersDetails()
        {
            List<string> ret = new List<string>();
            foreach (string user in ConsoleApplication1.Global.AllActiveUsers) //here is the problem
            {
                //TODO: write logic
            }
            return ret;
        }
    }
