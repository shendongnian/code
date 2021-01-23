    public class AuthorizationList : List<Tuple<Control, GroupList, UserList>>
    {
    	public void Add(Control control, GroupList groups, UserList users)
    	{
    		Add(new Tuple<Control, GroupList, UserList>(control, groups, users));
    	}
    	public void Add(Control control, GroupList groups)
    	{
    		Add(new Tuple<Control, GroupList, UserList>(control, groups, new UserList()));
    	}
    	public void Add(Control control, UserList users)
    	{
    		Add(new Tuple<Control, GroupList, UserList>(control, new GroupList(), users));
    	}
    }
