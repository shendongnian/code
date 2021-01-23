        public ActionResult Contact(ContactModel model)
        {
            ViewBag.Message = "Your contact page.";
            return View(model);
        }
        public ActionResult SaveContact(ContactModel model)
        {
            //process values in your model and then rest model
            ContactModel.Message = "Thank you for contacting us"; //show thank you message
            return RedirectToAction("Contact",model);
        }
