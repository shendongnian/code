    [TestFixture]
    public class AsyncSetupTest
    {
        private Task<CreateTicketViewModel> viewModelTask;
        [SetUp()]
        public void SetUp()
        {
            viewModelTask = Task.Run(async () =>
            {
                IUserService userService = Dependency.Instance.Resolve<IUserService>();
                await userService.LoginAsync(this.UserName, this.Password);
                return Dependency.Instance.Resolve<CreateTicketViewModel>();
            });
        }
        [Test()]
        public async Task Initialization()
        {
            CreateTicketViewModel viewModel = await viewModelTask;
            Assert.IsNotNull(viewModel);
            Assert.IsNotNull(viewModel.Ticket);
        }
    }
