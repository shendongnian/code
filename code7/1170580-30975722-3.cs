        [HttpPost]
        public ActionResult Create(FileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var image = new Image();
                model.SaveAs(HttpContext.Server.MapPath("../../Content/img/upload/") + model.FileName);
                image.ImagePath = model.FileName;
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create", "Images");
        }
