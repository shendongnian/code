    public ActionResult GetSession()
    {
    var SeesionValue = Session["UserRole"] !=null ? Session["UserRole"].ToString() : "";
    return Content(SeesionValue );
    }
