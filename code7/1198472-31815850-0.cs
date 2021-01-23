    public ActionResult ImagePage()
        {
           ViewBag.ImageSrc = GetMeMyImagePath();
           return View();
        }
