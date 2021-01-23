    public class DBDisplayViewModel
    {
    	private ObservableCollection<User> users;
    	
    	public DBDisplayViewModel() {
    		Load();
    	}
    	
    	public IUserRepository UserRepository
    	{
    		get; set;
    	}
    	
    	public ObservableCollection<User> Users
    	{
    		get {
    			if(users == null) {
    				users = new ObservableCollection<User>();
    			}
    			
    			return users;
    		}
    		set {
    			if(value != null) {
    				users = value;
    			}
    		}
    	}
    	
    	private void Load() {
    		List<User> users = UserRepository.GetUsers();
    		Users = new ObservableCollection<User>(users);
    	}
    }
