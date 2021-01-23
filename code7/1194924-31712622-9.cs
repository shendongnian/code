    public class TestModel
    {
        public string Name{get;set;}
        public string PublisherId{get;set;}
        public string AccountType{get;set;}
        public UserData UserData {get;set;}         //There will be a UserData model
        public List<Menu> MenuList {get;set;}       //There will be a Menu model
        public List<UserItem> UserItems {get;set;}  //There will be a UserItem model
    }
	public class UserData {}
	public class Menu {}
	public class UserItem {}
