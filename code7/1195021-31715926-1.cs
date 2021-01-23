    public MyMiddlewareComponent(AppFunc next, MyMiddlewareConfigOptions options)
    {
        _next = next;
        _greeting = options.GetGreeting();
    }
