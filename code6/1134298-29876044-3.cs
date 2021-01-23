    [HttpPost
    public ActionResult Register(Register model)
    {
        if (!ModelState.IsValid)
        {
          return View(model);
        }
        User user = new User()
        {
          UserName = model.UserName,
          Password = model.Password
        }
        // Save the user
        // Redirect to another view (e.g. the home page) - NOT return the view
    }
