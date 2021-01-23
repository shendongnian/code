	public class TestAPI : ITestAPI
	{
		private IUserDataService 	userDataService;
		private IMenuService 		menuService;
		private IUserItemsService  	userItemsService;
		public TestAPI(IUserDataService userDataService, IMenuService menuService, IUserItemsService userItemsService)
		{
			this.userDataService 	= userDataService;
			this.menuService		= menuService;
			this.userItemsService	= userItemsService;
		}
		public TestModel GetTestModel(string id)
        {
            var testModel = new TestModel();
            testModel.UserData  = this.userDataService.GetUserData(id);
            testModel.MenuList  = this.menuService.GetMenus(id);
            testModel.UserItems = this.userItemsService.GetUserItems(id);
			return testModel;
        }   
	}
