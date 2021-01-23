    [HttpPost]
    public JsonResult Login(MyLoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Do something here (probably use Umbraco internal's authorization layer)
            var valid = (model.UserName == "user" && model.Password == "pwd");
            if (valid)
                return Json(new { code = 0, message = "OK" });
            else
                return Json(new { code = 10, message = "User/Password does not match" });
        }
        // Model is invalid, report error
        return Json(new { code = -1, message = "invalid arguments" });
    }
