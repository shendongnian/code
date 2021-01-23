    [Route("core/Register")]
    [HttpGet]
    [AllowAnonymous]
    public ActionResult Register(string signin)
    {
        Response.Cookies.Add(new HttpCookie("signin", signin)); // Preserve the signin so we can use it to automatically redirect user after registration process
        return View(new RegisterViewModel());
    }
