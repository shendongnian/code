    [HttpPost]
    public ActionResult Login(string userName,string password)
    {
       //if userName and password are valid
           return Json(new { Status="success"});
       // else
             return Json(new { Status="failed", Message="Invalid credentials});
    }
