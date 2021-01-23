    [Fact]
    public void Ensure_Proper_Btn_Validated_Return_True()
    {
        var blogsTestData = new List<Blog>();
        var blogs = MockDbSet(blogsTestData);
        var dbContext = new Mock<IDbContext>();
        //Set up mocks for db sets
        dbContext.Setup(m => m.Blogs).Returns(blogs.Object);
        var validator = new BtnValidator(dbContext.Object);
        //...other code removed for brevity
    }
    Mock<DbSet<T>> MockDbSet<T>(IEnumerable<T> list) where T : class, new() {
        IQueryable<T> queryableList = list.AsQueryable();
        Mock<DbSet<T>> dbSetMock = new Mock<DbSet<T>>();
        dbSetMock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryableList.Provider);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryableList.Expression);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryableList.ElementType);
        dbSetMock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryableList.GetEnumerator());
        dbSetMock.Setup(x => x.Create()).Returns(new T());
        return dbSetMock;
    }
