    public ActionResult Login(string username, string password)
    {
        var userService = new UserService();
        var loginResult = userService.ValidatePassword(username, password);
        if (loginResult == null) return Redirect("/");
        Response.Cookies.Add(new HttpCookie("tok", Uri.EscapeDataString(userService.CreateToken(loginResult)))
        {
            Expires = DateTime.Now.AddYears(1)
        });
        return Redirect("/admin");
    }
