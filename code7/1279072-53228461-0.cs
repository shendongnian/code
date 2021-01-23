    [HandleError(ExceptionType = typeof(HttpException), View = "ConfirmEmail")]
    public ActionResult ConfirmEmail(string userId = null, string code = null)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }
            else
            {
                var user = DBContext.Users.Find(userId);
                user.EmailConfirmed = true;
                DBContext.SaveChanges();
                throw new HttpException(result.Errors.FirstOrDefault());
            } 
        }
