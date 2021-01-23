    [HttpPost]
    public ActionResult Register(UserViewModel userViewModel)
    {
        User user = // map UserViewModel to User and get user object.
        // pass user object to data layer.
        _userService.Register(user);
    }
