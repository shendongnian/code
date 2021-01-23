    var loginResult = udb.loginUser(form.Username, form.Password);
    if (!string.IsNullOrEmpty(loginResult))
    {
        Session["userName"] = form.Username;
        return RedirectToRoute("Home");
    }
