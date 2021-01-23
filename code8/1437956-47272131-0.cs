    Nice,     
        [HttpPost]
        [Route("User")]
        public ActionResult PostUser(UserViewModel model) {
            if (ModelState.IsValid) {
                _usersService.UpdateUserRoles(model.User);
                return RedirectToAction("Index");
            }enter code here
    
            return View("User", model);
        }
