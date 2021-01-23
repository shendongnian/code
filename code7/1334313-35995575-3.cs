    public class GroupList : List<byte> { }
    public class UserList  : List<byte> { }
    public class Authorization
    {
        public Control    Control   { get; set; }
        public GroupList  Groups { get; set; }
        public UserList   Users { get; set; }
    }
    public class AuthorizationList : List<Authorization>
    {
        public void Add(Control control, GroupList groupList, UserList userList)
        {
            Add(new Authorization
            {
                Control = control,
                Groups = groupList,
                Users = userList
            });
        }
        public void Add(Control control, GroupList groupList)
        {
            Add(control, groupList, null);
        }
        public void Add(Control control, UserList userList)
        {
            Add(control, null, userList);
        }
    }
