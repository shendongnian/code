    [HttpGet]
    public JsonResult IsEmailAdminExist(string Email)
    {
        // Clean up your e-mail
        var email = Email.ToLower.Trim();
        return Json(!AdminContext.admins.Any(a => a.Email.ToLower() == email), JsonRequestBehavior.AllowGet);
    }
