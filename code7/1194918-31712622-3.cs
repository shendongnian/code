    public class UserDataService : BaseHttpServiceClient<UserData, string>, IUserDataService
    {
		public UserDataService(string remoteUri) : base(remoteUri) {}
        public UserData GetUserData(string id) { return this.GetRemoteItem(id); }
	}
	public class MenuService : BaseHttpServiceClient<List<Menu>, string>, IMenuService
	{
		public MenuService(string remoteUri) : base(remoteUri) {}
        public List<Menu> GetMenus(string id) { return this.GetRemoteItem(id); }
	}
	public class UserItemsService : BaseHttpServiceClient<List<UserItem>, string>, IUserItemsService
	{
		public UserItemsService(string remoteUri) : base(remoteUri) {}
        public List<UserItem> GetUserItems(string id) { return this.GetRemoteItem(id); }
    }
