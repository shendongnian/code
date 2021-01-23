        [HttpPost]
        public ActionResult UserAddress(UserAddress model)
        {
            if (ModelState.IsValid) //you'll get false here if CityCode or ContryCode don't exist in Db
            {
                //do stuff
            }
            return View("UserAddress", model);
        }
