    [System.Web.Services.WebMethod(BufferResponse=false)]
    public static Task<bool> getLogin(string username, string password)
    {
        Login login = new Login();
        return login.verifyLogin(username, password);
    }
    async Task FooBar()
    {
        boolean isLoggedIn = await _loginService.getLogin(this.Username, this.Password);
    }
