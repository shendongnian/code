    [HttpPost]
        public ContentResult Index(Mvcajaxtest.Models.mymodal mr)
        {
            if (ModelState.IsValid)
            {
                mr.inserttdata();
                ModelState.Clear();
                return Content("Inserted");
            }
            return Content("Invalid");
        }
