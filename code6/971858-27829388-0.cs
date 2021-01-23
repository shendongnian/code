    using (AccountController controller = new AccountController())
    {
        StubHttpContextBase stubHttpContext = new StubHttpContextBase();
    
        controller.ControllerContext = new ControllerContext(stubHttpContext, new RouteData(), controller);
    
        StubIPrincipal principal = new StubIPrincipal();
        principal.IdentityGet = () =>
        {
            return new StubIIdentity 
            { 
                NameGet = () => "bob" 
            };
        };
        stubHttpContext.UserGet = () => principal;
    }
