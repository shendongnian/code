    [Test, TestCaseSource("GetUserLists")]        
    public void MyExample_Test(IList<User> users)
    {   
        Asset.Pass();
    }
    private static IEnumerbale<List<User>> GetUserLists()
    {
        IList<User> users = new List<User>();
        users.Add(new User());
        users.Add(new User());
        users.Add(new User());
        users.Add(new User());
        return new [] { users };
    }
