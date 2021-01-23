        [HttpGet]
        public ActionResult Register() {
            var model = new RegisterViewModel();
            model.Items = new SelectList(RegisterViewModel.VideoProviderDictionary, "key", "value");
            return View(model);
        }
