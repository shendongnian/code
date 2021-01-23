    [TestInitialize]
    public void Initialize()
    {
        var repoMock = new Mock<IRepository>();
    
        var objectsList = new List<myCustomObject>() {
            new myCustomObject("Something"), 
            new myCustomObject("Otherthing")
        }
    
        repoMock.Setup<Task<IEnumerable<myCustomObject>>>(
            rep => rep.GetSomethingAsync("ThisParam")
        ).Returns(Task.FromResult<IEnumerable<myCustomObject>>(objectsList));
    }
