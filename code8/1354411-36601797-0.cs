    public class ApplicationVm
    {
        private readonly IInteractionService interactionService;
        private readonly IDataService dataService;
        private async Task LoadDataAsync()
        {
            try
            {
                // we need to ask for credentials
                var loginVm = new LoginVm();
                if (interactionService.ShowInDialog(loginVm) == true)
                {
                    // performing login
                    var userId = await dataService.LoginAsync(loginVm.UserName, loginVm.Password);
                    // setting content to general view model, which is the payload of our app
                    Content = new GeneralVm(userId, dataService);
                }
                else
                {
                    // setting content to stub, which shows us "Login cancelled" message
                    Content = new StubVm { Message = "Login cancelled" };
                }
            }
            catch (Exception ex)
            {
                // setting content to stub, which shows us "Login failed" message
                Content = new StubVm { Message = $"Login failed: {ex.Message}" };
            }
        }
        public ApplicationVm(IInteractionService interactionService, IDataService dataService)
        {
            this.interactionService = interactionService;
            this.dataService = dataService;
            var _ = LoadDataAsync();
        }
        public object Content { get; private set; }
    }
    public interface IInteractionService
    {
        bool? ShowInDialog(object viewModel);
    }
    public interface IDataService
    {
        Task<int> LoginAsync(string userName, string password);
        Task<IEnumerable<Friend>> GetFriendsAsync(int userId);
    }
    public class LoginVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class GeneralVm
    {
        private readonly int userId;
        private readonly IDataService dataService;
        private async Task LoadFriendsAsync()
        {
            var friends = await dataService.GetFriendsAsync(userId);
            Friends = friends
                .Select(model => new FriendVm(userId, model));
        }
        public GeneralVm(int userId, IDataService dataService)
        {
            this.userId = userId;
            this.dataService = dataService;
        }
        public IEnumerable<FriendVm> Friends { get; private set; }
    }
    public class FriendVm
    {
        public FriendVm(int userId, Friend model)
        {
        }
    }
    public class Friend { }
    public class StubVm
    {
        public string Message { get; set; }
    }
