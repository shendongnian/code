    public ActionResult Registrationform()
    {
        if (Session["UserID"] == null)
        {
            return RedirectToAction("Index", "Main");
        }
        else
        {
            return View();
        }
    }
