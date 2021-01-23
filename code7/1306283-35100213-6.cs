    [Route("Kaminy/KaminniTopky")] 
    public ActionResult KaminniTopky()
    {
        return View();
    }
    [Route("Kaminy/KaminniTopky/{id}")] 
    public ActionResult KaminniTopky(int id)
    {
        return View("OtherViewName");
    }
