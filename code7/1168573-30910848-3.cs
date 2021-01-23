    var mockRepository = new Mock<IEFBlogRepository>();
    mockRepository.Setup(r => r.....);
    
    var thing = new Thing(mockRepository.Object);
    thing.DoSomeStuffWhichCallsRepository();
