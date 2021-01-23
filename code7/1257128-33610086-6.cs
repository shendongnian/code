    public class UserHelper
    {
        private static UserHelper theOneAndOnlyInstance = null;
        public static IRepository Repository {get; set;}
        // private constructor, so no one can create an instance
        private UserHelper() {}
        // the function to get the one and only instance
        public static UserHelper TheOneandOnlyUserHelper
        {
            get 
            {
                if (theOneAndOnlyInstance == null)
                {
                    theOneAndOnlyInstance = new UserHelper();
                }
                return theOneAndOnlyInstance;
            }
        }
    }
