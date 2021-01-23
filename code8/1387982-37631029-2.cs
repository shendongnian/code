    [Fact]
    public void Ensure_Proper_Btn_Validated_Return_True()
    {
        var dbContext = new Mock<IDbContext>();
        //Set up mocks for db sets
        dbContext.Setup(m => m.Blogs).Returns(mockMyDbSet());
        var validator = new BtnValidator(dbContext.Object);
        //...other code removed for brevity
    }
