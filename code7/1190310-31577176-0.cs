    [TestMethod]
    public void DoesSomething_behaves_correctly()
    {
         var expected = 42;
         var container = new UnityContainer();
         var foo = container.Resolve<DoesSomething>(); 
         int actual = foo.DoesImportant(21, 21); 
         Assert.AreEqual(expected, actual); 
    }
