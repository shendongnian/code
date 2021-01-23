        private Mock<IUserStore<User>> UserStoreMock { get; set; }
        [SetUp]
        public void SetUp()
        {
            UserStoreMock = new Mock<IUserStore<User>>();
            UserStoreMock.Setup(x => x.FindByIdAsync(It.IsAny<string>(), CancellationToken.None))
                .Returns(Task.FromResult(new User() {Year = 2020}));
        }
        [TestCase(2020)]
        public async Task ValidateUserYear(int year)
        {
            var userManager = new UserManager<User>(UserStoreMock.Object, null, null, null, null, null, null, null, null);
            var userManagerWrapper = new UserManagerWrapper(userManager, new UserModelFactory(), null);
            var findByIdAsync = await userManagerWrapper.FindByIdAsync("1");
            Assert.AreEqual(findByIdAsync.Year, year);
        }`:
