    [SetUp]
    public void Setup()
    {
       var username = "username@test.io";
       string[] roles = new[] { "Admin", "SuperUser" };
       var mockIdentity = new MyUser(username) {
           Id = 1,
           CompanyId = 99
       };
       _controller = new MyController(){
           ... repositories....
           MyUser = MockMyUser()
       };
       _controller.ControllerContext = new ControllerContext() {
            Controller = _controller,
            RequestContext = new RequestContext(new MockHttpContext(mockIdentity, roles), new RouteData())
        };
    }
