        [HttpPost]
		public ActionResult Create(EventModel eventmodel, HttpPostedFileBase file)
		{
			if (ModelState.IsValid)
			{
				var originalFilename = Path.GetFileName(file.FileName);
				string fileId = Guid.NewGuid().ToString().Replace("-", "");
				string userId = GetUserId(); // Function to get user id based on your schema
				var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), userId, fileId);
				file.SaveAs(path);
				eventModel.ImageId = fileId;
				eventmodel.OriginalFilename = originalFilename;
				_db.EventModels.AddObject(eventmodel);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(eventmodel);
		}
