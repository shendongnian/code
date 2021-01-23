    [HttpPost]
    public ActionResult ChangePassword(ChangePasswordModel model)
    {
        string errorMsg = "";
        if (ModelState.IsValid)
        {
            // ChangePassword will throw an exception. We rather
            // want to return false in certain failure scenarios.
            bool changePasswordSucceeded;
            try
            {
                MembershipUser currentUser = Membership.GetUser(User.Identity.Name);
                changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
            }
            catch (Exception ex)
            {
                changePasswordSucceeded = false;
                errorMsg = ex.Message;
            }
            return Json(new { Validated = changePasswordSucceeded, Message = errorMsg }, JsonRequestBehavior.AllowGet);
        }
        return View();
    } 
