    public class UserAdapter
    {
        public ExternalUser refToUser {get; private set;}
        //expose the methods you need here
        //eg:
        public void SomeMethod(int someParameter)
        {
            refToUser.SomeMethod(someParameter);
        }
        public UserAdapter(ExternalUser usr)
        {
        refToUser = usr;
        }
    }
