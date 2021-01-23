    [HttpPost]
    public ActionResult Validate(string ManagerId , string UserId )
    {
      // put some validation involving ManagerId and UserId here
      return Json(true);
    }
