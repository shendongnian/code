    public ActionResult ChangePassword(ChangePasswordMessageId? message. int mobile = 0)
    {
        // your code
        ViewBag.Mobile = mobile;
        return View();
    }
    [HttpPost]
    public ActionResult ChangePassword(ChangePasswordViewModel model, int mobile = 0)
    {
        // your code
        ViewBag.Mobile = mobile;
        return View(model);
    }
