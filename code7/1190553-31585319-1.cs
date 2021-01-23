            [HttpGet]
        public ActionResult Add(string id)
        {
            var model = new StudentMarkAssignViewModel[]
            {
                new StudentMarkAssignViewModel {StudentId = 1, FullName = "Martin", Mark = 0 },
                new StudentMarkAssignViewModel {StudentId = 2, FullName = "Robert", Mark = 5 }
            };
            //here i use hardcoded valuse, but you should get them from your db
            return View(model);
        }
