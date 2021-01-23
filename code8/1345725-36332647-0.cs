    public void Configuration(IAppBuilder app)
    {
       app.UseBasicAuthentication("MyAppAuthRealm", ValidateUser);
        ...
    }
