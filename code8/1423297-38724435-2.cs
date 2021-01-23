    [Http.POST]
    public ActionResult ConfirmPassword(string passWord) {
        if (passWord == MY_SECRET_PASSWORD) {
            return View("SecretInformationPage");
        } else {
            return View ("PageThatPromptsForPassword");
        }
    }
