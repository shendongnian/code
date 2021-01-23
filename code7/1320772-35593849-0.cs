    public JsonResult IsEmailValid(string email)
    {
        bool isValid = IsEmailUnique(email);
        return Json(isValid, JsonRequestBehavior.AllowGet);
    }
