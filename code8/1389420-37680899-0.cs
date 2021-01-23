    [Fact]
    public void GetAllBtnRules_Should_Return_All_BtnRules()
    {
        var repo = new Mock<IBtnRulesRepository>();
        
        var testBtnRules = GetTestBtnRules();
        repo.Setup(mock => mock.GetRestrictions())
            .Returns(testBtnRules)
            .Verifiable();
        var controller = new BtnRulesController(repo.Object);
        var result = controller.Get();
        Assert.Equal(testBtnRules.Count,result.Count);
        repo.Verify();
    }
