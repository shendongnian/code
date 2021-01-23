        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Step1")]
        public ActionResult Step1(YourModelType model)
        {}
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "Step2")]
        public ActionResult Step2(YourModelType model)
        {}
