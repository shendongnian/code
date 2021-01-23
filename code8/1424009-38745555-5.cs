        public ActionResult Test()
        {
            return View("Test1", new AModel());
        }
        [HttpPost]
        public ActionResult Save(AModel model)
        {
            if (model.PostType == "Add")
            {
                model.BModel.DModels.Add(new DModel());
                return View("Test1", model);
            }
            // Do something with this final model
            return View("Test1");
        }
