        public class UserManager
    {
        private readonly ILabinatorDb _liLabinatorDb;
        public UserManager(ILabinatorDb liLabinatorDb)
        {
            _liLabinatorDb = liLabinatorDb;
        }
        public void CreateNewUser(string userName)
        {
            User existingUser = _liLabinatorDb.Query<User>().FirstOrDefault(u => u.UserName == userName);
            if (existingUser == null)
            {
                User userToAdd = new User();
                userToAdd.UserName = userName;
                _liLabinatorDb.Add<User>(userToAdd);
                _liLabinatorDb.SaveChanges();
            }
        }
    }
     [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenAUsernameWhenNoUserExistsInDatabaseThenNewUserCreated()
        {
            var mockDatabase = new Mock<ILabinatorDb>();
            mockDatabase.Setup(a => a.Query<User>()).Returns(new List<User>().AsQueryable());
            var userManager = new UserManager(mockDatabase.Object);
            userManager.CreateNewUser("UserDoesntExistInDatabase");
            mockDatabase.Verify(a => a.Add(It.IsAny<User>()),Times.Once);
            mockDatabase.Verify(a => a.SaveChanges(),Times.Once);
        }
        [TestMethod]
        public void GivenAUsernameWhenUserExistsInDatabaseThenNewUserNotCreated()
        {
            var mockDatabase = new Mock<ILabinatorDb>();
            var mockedUsers = new List<User>
            {
                new User {UserId = 2, UserName = "UserExistsInDatabase"}
            };
            mockDatabase.Setup(a => a.Query<User>()).Returns(mockedUsers.AsQueryable());
            var userManager = new UserManager(mockDatabase.Object);
            userManager.CreateNewUser("UserExistsInDatabase");
            mockDatabase.Verify(a => a.Add(It.IsAny<User>()), Times.Never);
            mockDatabase.Verify(a => a.SaveChanges(), Times.Never);
        }
    }
