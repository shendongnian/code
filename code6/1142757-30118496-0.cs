    [TestMethod]
    public void TestMethod1()
    {
        Debug.WriteLine("METHOD");
        //Arrange
        HomeController ctrl = new HomeController();
        Debug.WriteLine("Pass");
        //Act
        ViewResult r = ctrl.Index() as ViewResult;
        //Asert
        Assert.AreEqual("View1", r.ViewName);
    }
