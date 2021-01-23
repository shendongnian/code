        [HttpPost]
        public ActionResult Index(MyModel model)
        {
            // You can see here reason for fail
            var errors = ModelState.Values.SelectMany(v => v.Errors); 
            if (ModelState.IsValid)
            {
                //other stuff
            }
        }
