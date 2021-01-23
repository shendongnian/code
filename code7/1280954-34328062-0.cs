    [HandleError(ExceptionType = typeof(ArgumentException), View = "~/Views/SetValues/Error")]
    public ActionResult Index(int? id)
    {
            if(id==null)
            {
                ViewBag.Error = "A null parameters passed to the function";
                return View("Error");
            }
            try
            {
                 .........
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View("Error");
            }
    } 
