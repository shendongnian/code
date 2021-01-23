    public class UnitTestClass
    {
        public string UserName {get;set;}
        public string Password {get;set;}
    
        [TestInitialize]
        public void Setup() 
        {
            UserName = "test";
            Password = "test123";
        }
    
        [TestMethod]
        public void When_ValidUserCredentials_Expect_UserIsNotNull()
        {
            var mockAuthenticationService = new Mock<IAuthenticateService>();
            mockAuthenticationService.Setup(m => m.Login(ValidUserName, ValidPassword)).Returns(ValidUserDto);
    
            var mockAuthorizationService = new Mock<IAuthorizeService>();
            mockAuthorizationService.Setup(m => m.GetAllPermissions(ValidUserId)).Returns(ValidPermissionList);
    
    		// Here we are "injecting" the dependencies into the AuthClient
            var authClient = new AuthClient(mockAuthenticationService.Object, mockAuthorizationService.Object);
            // This service call will now use the supplied (mocked) services above
            User user = authClient.Login(UserName, Password); 
    
            Assert.IsNotNull(user);
        }
    }
