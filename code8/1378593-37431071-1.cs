    public ActionResult Photos(string userName)
    {
        UserPhotosVM model = new UserPhotosVM()
        {
            UserName = userName,
            Photos = .....
        }
        return View(model);
    }
