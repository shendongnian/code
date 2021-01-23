    public class MyADUserClass : UserPrincipal {}
    
    public class MyLocalUser
    {
        public MyLocalUser(MyADUserClass user)
        {
            //Do something here based upon user.Properties
        }
    }
    
    public class MySystemsHandler
    {
        public List<MyADUserClass> FetchAllADUsers(...) {}
        public void CopyADUsertoLocal(List<MyADUserClass> ADUsers)
        {
            foreach(MyADUserClass aduser in ADUsers) 
            { 
                MyLocalUser luser = new MyLocalUser(aduser);
                ... //copy to local store here
            }
        }
    }
