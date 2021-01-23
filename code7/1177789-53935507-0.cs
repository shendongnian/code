    var mockRequest = new Mock<HttpRequestBase>();
    var mockCollection = new Mock<HttpFileCollectionBase>();
    var mockFile = new Mock<HttpPostedFileBase>();
    
    // mock a file
    mockFile.Setup(x => x.FileName).Returns("test.jpg");
    mockFile.Setup(x => x.ContentLength).Returns(1000);
    
    // setup the collection
    var array = new[] {mockFile.Object};
    mockCollection.Setup(x => x.GetEnumerator()).Returns(array.Select(f => f.FileName).GetEnumerator());
    mockCollection.Setup(x => x.Count).Returns(array.Count());
    mockCollection.Setup(x => x[It.IsAny<int>()]).Returns((int i) => array[i]);
    mockCollection.Setup(x => x[It.IsAny<string>()]).Returns((string n) => array.FirstOrDefault(f => f.FileName == n));
    
    // setup the request
    mockRequest.Setup(x => x.Files)(mockCollection.Object);
    
    mockRequest.Object.Files[0].Should().NotBeNull();
