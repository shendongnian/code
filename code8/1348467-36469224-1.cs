    [TestMethod, Isolated]
    public void TestAddWithEmptyDb()
    {
        //Arrange
        var fakeDb = Isolate.Fake.AllInstances<FakeDatabase>(Members.CallOriginal);
        var userList = new List<User>();
        Isolate.WhenCalled(() => fakeDb.Query<User>()).WillReturnCollectionValuesOf(userList.AsQueryable());
    
        //Act
        UnderTest test = new UnderTest();
        test.get("newName");
    
        //Assert
        Isolate.Verify.WasCalledWithArguments(() => fakeDb.Add<User>(null)).Matching(a => (a[0] as User).UserName == "newName");
        Isolate.Verify.WasCalledWithAnyArguments(() => fakeDb.SaveChanges());
    }
