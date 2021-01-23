    [Fact]
    public void TestInvalidViewModels()
    {
        //Arrange
        TestProjectRepository testRepo = new TestProjectRepository();
        var username = "username@example.com";
        var identity = new GenericIdentity(username, "");
        var principal = new GenericPrincipal(identity, roles: new string[] { });
        var fakeUser = new ClaimsPrincipal(principal); 
        var controller = new EntryController(testRepo, null);
        controller.User = fakeUser;
        //Act
        var result = controller.Get("01/12/1899");
        //Assert
        Assert.Equal(result, null);
    }
