    [TestMethod]
        public void Should_Add_User()
        {
            var mockSet = new Mock<DbSet<User>>();
            var mockContext = new Mock<DTContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            var usrCRUD = new UserCRUD(mockContext.Object);
            var usr = new User();
            usr.Login = "Login_Name";
            usr.Email = "loginName@test.com";
            usr.Password = "***";
            usr.InvalidLogins = 0;
            usr.RememberID = 0;
            usrCRUD.AddUser(usr);         
            mockSet.Verify(m => m.Add(It.Is<User>(arg => arg.Login == "Login_Name")));            
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
