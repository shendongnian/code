    public ActionResult Messages()
    {
        ViewBag.MyMessage = "This is my Partial Message";
        return PartialView();
    }
