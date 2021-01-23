    public JsonResult EmailValidation(string email)
        {
            var user = _service.FindByEmail(email);
            return user == null
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(new {result = false, message = "Email is in use"}, JsonRequestBehavior.AllowGet);
        }
