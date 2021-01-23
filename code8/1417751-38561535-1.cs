    var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
    {
        new Claim(ClaimTypes.Name, "username"), // This will make user.Identity.Name return "username"
        new Claim(ClaimTypes.NameIdentifier, "1"),
        new Claim(MyCustomClaim, "example claim value")
    }));
    var controller = new SomeController(dependencies…);
    controller.ControllerContext = new ControllerContext()
    {
        HttpContext = new DefaultHttpContext() { User = user }
    };
