        [HttpGet]
        public ActionResult Edit(string id, ManageMessageId? message = null)
        {
            var user = _db.Users.First(u => u.UserName == id);
            var model = new UserUpdateViewModel(user);  // move entity fields to viewmodel from constructor, automapper, etc.
            ViewBag.MessageId = message;
            return View(model);
        }
