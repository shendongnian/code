    public class GroupList : List<byte> { }
    public class UserList  : List<byte> { }
    public class Authorization
    {
        public Control    Control   { get; set; }
        public List<byte> GroupList { get; set; }
        public List<byte> UserList  { get; set; }
    }
    public class AuthorizationList : List<Authorization>
    {
        public void Add(Control control, GroupList groupList, UserList userList)
        {
            Add(new Authorization
            {
                Control = control,
                GroupList = groupList,
                UserList = userList
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
