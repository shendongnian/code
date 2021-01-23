    public class RemoteController : Controller
        {
            [AcceptVerbs(HttpVerbs.Post)]
            public JsonResult IsValidUserName()
            {
                string email= Request.Form["Email"];  
                string message = "Email '"+ email+ "' is already taken";
                if (!string.IsNullOrEmpty(email))
                {
                    using (DbContext db = new DbContext())
                    {
                        if (!db.tb_Users.Any(x => x.email== email))
                        {
                            message = string.Empty;
                        }
                    }
                }
                if (message == string.Empty)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(message, JsonRequestBehavior.AllowGet);
            }
    }
