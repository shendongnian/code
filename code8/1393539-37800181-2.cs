    public class UserRepository:IUserRepository
    {
       public UserRepository(){
        // you usually instanciate your context here
        // private AzMeritContext db = new AzMeritContext();
       }
       User GetUserById(int Id){
       // do your query to get a single user
       }
    }
