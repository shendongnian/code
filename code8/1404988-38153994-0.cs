     [HttpPost]
     public ActionResult Index(int userId)
        {
            // user ID is binded to userId variable, based on the input name
            var model = populate(userId);
            // Remember to return the model to the view
            return View(model, "~/Views/FingerprintTool/Index.cshtml");
        }
