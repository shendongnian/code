    [HttpPost]
            public ActionResult Create(YourViewModel model)
            {
              foreach(var student in model.Students)
              {
                if(student.Selected) { // Do your logic}
              }
            }
