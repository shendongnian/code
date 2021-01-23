    var carData = new List<Car>{new Car{ Trim = "Whatever" }};  
    var mockCarSet = new Mock<DbSet<Car>>();
    mockCarSet.As<IQueryable<Car>>().Setup(m => m.Provider).Returns(carData.Provider);
    mockCarSet.As<IQueryable<Car>>().Setup(m => m.Expression).Returns(carData.Expression);
    mockCarSet.As<IQueryable<Car>>().Setup(m => m.ElementType).Returns(carData.ElementType);
    mockCarSet.As<IQueryable<Car>>().Setup(m => m.GetEnumerator()).Returns(carData.GetEnumerator);
    var mockMakeSet = new Mock<DbSet<Make>>();
    //do the same stuff as with Car for IQueryable Setup
    var mockModelSet = new Mock<DbSet<Model>>();
    //do the same stuff as with Car for IQueryable Setup
    using(ShimsContext.Create())
    {
        //hack to return the first, since this is all mock data anyway
    	ShimModel.AllInstances.MakeGet = model => mockMakeSet.Object.First();
    	ShimCar.AllInstances.ModelGet = car => mockModelSet.Object.First();
    	//run the test
    }
