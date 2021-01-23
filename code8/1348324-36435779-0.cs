    [TestMethod]
    public void SomeMyAPIControllerTest(){
        // Arrange
        var config = new HttpConfiguration();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("http://localhost:50268/api/MyAPI");
        request.Headers.Add("x-zumo-auth", "_user_auth_token_");
        request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        //Create test user
        var username = "username@example.com"
        var identity = new GenericIdentity(username, "");
        var principal = new GenericPrincipal(identity, roles: new string[] { });
        var user = new ClaimsPrincipal(principal);
        // Set the User on the controller directly
        var controller = new MyAPIController(TestContext)
        {
            Request = request,
            User = user
        };
    
        //Act
        var response = controller.SomeMethod();
    
        //Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }
