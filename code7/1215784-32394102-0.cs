    // [Authorize]
    public ActionResult Checkout(string message)
    {
        if(message==null)
        {
            message = "";
        }
        ViewBag.Message = message;
        if (!User.Identity.IsAuthenticated) {
            return RedirectToAction("Login","Account", new { message = "You Need to Login to Checkout!" });
        }
		/.../
