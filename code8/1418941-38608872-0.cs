            [HttpPost]
            public ActionResult Index(Mvcajaxtest.Models.mymodal mr)
            {
                if (ModelState.IsValid)
                {
                    mr.inserttdata();
                    ModelState.Clear();
                    @ViewBag.msg = "Inserted";
                }
    
                return View();
            }
