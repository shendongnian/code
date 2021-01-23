    [HttpGet]
       public ActionResult Register()
       {
            var model = new RegisterViewModel();
            Viewbag.Items = new SelectList(VideoProviders.VideoProviderDictionary);
            ......
            return View(model);
       }
