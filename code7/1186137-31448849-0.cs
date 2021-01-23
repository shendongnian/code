    private static DbSet<T> GetMockDBSet<T>(Func<List<T>> setupAction) where T : class
    {
        var mockDBSet = new Mock<DbSet<T>>();
        var mockedData = setupAction.Invoke().AsQueryable();
        mockDBSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(mockedData.Provider);
        mockDBSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(mockedData.Expression);
        mockDBSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(mockedData.ElementType);
        mockDBSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(mockedData.GetEnumerator());
        return mockDBSet.Object;
    }
