    public ActionResult Index
    {
        if (Request.HttpMethod.ToString() == "POST")
        {
            // handle POST data
            string selectProcess = Request.Form("selectProcess");
            // process selectProcess data however you need
            return RedirectToAction("Index", "Home");
        }
        // handle GET view
        return View();
    }
