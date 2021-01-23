    public ActionResult LoginMethod(MyViewModel myViewModel)
    {
        if (myViewModel.Username == "admin" && myViewModel.Password == "admin1")
        {
            return RedirectToAction("Home");
        }
        else return RedirectToAction("Login");
    }
