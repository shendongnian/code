    [Fact]
    public void TestInvalidViewModels()
    {
        //Arrange        
        var username = "username@example.com";
        var identity = new GenericIdentity(username, "");
        var fakeUser = new GenericPrincipal(identity, roles: new string[] { });
        TestProjectRepository testRepo = new TestProjectRepository();
        var controller = new EntryController(testRepo, null);
        controller.User = fakeUser;
        //Act
        var result = controller.Get("01/12/1899");
        //Assert
        Assert.Equal(result, null);
    }
