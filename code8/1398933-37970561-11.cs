    [SetUp]
    public void Setup()
    {
       string[] roles = new[] { "Admin", "SuperUser" };
       var mockUser = MockMyUser();
       _controller = new MyController(){
           ... repositories....
           MyUser = mockUser
       };
       _controller.ControllerContext = new ControllerContext() {
            Controller = _controller,
            RequestContext = new RequestContext(new MockHttpContext(mockUser, roles), new RouteData())
        };
    }
    private IMyUser MockMyUser()
    {
        var u = new Mock<IMyUser>();
        u.Setup(x => x.Name).Returns("username@test.io");
        u.Setup(x => x.Id).Returns(1);
        u.Setup(x => x.CompanyId).Returns(99);
    
        return u.Object;
    }
