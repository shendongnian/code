    [SetUp]
    public void Setup()
    {
       var username = "username@test.io";
       string[] roles = new[] { "Admin", "SuperUser" };
    
       _controller = new MyController(){
           ... repositories....
           MyUser = MockMyUser()
       };
       _controller.ControllerContext = new ControllerContext() {
            Controller = controller,
            RequestContext = new RequestContext(new MockHttpContext(username, roles), new RouteData())
        };
    }
