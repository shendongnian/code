    public class AuthorizationList : List<Authorization>
    {
        public void Add(Control control, GroupList groups, UserList users)
        {
            Add(new Authorization
		    {
			    Control = control, 
			    GroupList = groups,
			    UserList =users
		    };
        }	
        public void Add(Control control, GroupList groups )
        {
           Add (control, groups, null);
        }
	
	    public void Add(Control control, UserList users)
        {		
           Add(control, null,users);
        }
    }
    
    public class Authorization
    {
    	public Control {get; set;}
    	public List<Group> GroupList {get; set;}
    	public List<User> UserList {get; set;}	
    }
