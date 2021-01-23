    [Test]
    public void Confirmation()
    {
        //arrange
        TestControllerBuilder builder = new TestControllerBuilder();
        var con = new xController();
        builder.InitializeController(con);
    
        //act
        var res = con.Confirmation("hello");
    
        //assert
        Assert.IsNotNull(res);
    }
