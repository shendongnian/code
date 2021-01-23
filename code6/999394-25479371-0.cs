    public static Mock<MyDataContext> GetMockedDbContext<T>(Expression<Func<MyDataContext, T>> func)
    {
        var context = new Mock<MyDataContext>();
    
        // Now what?
        context.Setup(func).Returns(mockDbSet.Object);
        return context;
    }
