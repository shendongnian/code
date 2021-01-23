    [ActionName("Index")]
        [HttpPost]
        public ActionResult IndexPost(string SubmitButton, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
    
            string buttonClicked = SubmitButton;
            if(buttonClicked == "Approve")
            {
                CurrentApplication currentApplication = db.CurrentApplications.Find(id);
                currentApplication.AppStatus = "APPROVED";
                db.SaveChanges();
    
            }
            else if(buttonClicked == "Unapprove")
            {
                CurrentApplication currentApplication = db.CurrentApplications.Find(id);
                currentApplication.AppStatus = "UNAPPROVED";
                db.SaveChanges();
    
            }
            //Save Record and Redirect
            return RedirectToAction("Index");
        }
