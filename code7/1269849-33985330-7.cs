        [HttpGet]
        public ActionResult Edit(string id, ManageMessageId? message = null)
        {
            var user = _db.Users.First(u => u.UserName == id);
            // move entity fields to viewmodel from constructor, automapper, etc.        
            var model = new UserUpdateViewModel 
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };  
            ViewBag.MessageId = message;
            return View(model);
        }
