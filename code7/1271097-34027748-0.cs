    public class BaseRepository<T>
    {
        protected RestClient client;
        protected string url;
    
        public BaseRepository ()
        {
            client = RestClient.GetInstance ();
        }
    
        public async Task<T> Find(string id) {
            dynamic response = await client.Find(url, id);
    
            return DeserializeItem<T> (response);
        }
    }
    public class UsersRepository : BaseRepository<User>
    {
        static UsersRepository instance;
    
        private UsersRepository ()
        {
            url = "users";
        }
    
        public static UsersRepository GetInstance() {
            if (instance == null) {
                instance = new UsersRepository ();
            }
    
            return instance;
        }
    }
