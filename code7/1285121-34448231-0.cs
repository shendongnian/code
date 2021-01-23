    [ActionName("Index")]
    [HttpPost]
    public ActionResult IndexPost(string button, int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        string buttonClicked = Request.Form["SubmitButton"];
        if(buttonClicked == "Approve") // value of Approve button
        {
            CurrentApplication currentApplication = db.CurrentApplications.Find(id);
            currentApplication.AppStatus = "APPROVED";
            db.SaveChanges();
        }
        else if(buttonClicked == "Unapprove") // value of Unapprove button
        {
            CurrentApplication currentApplication = db.CurrentApplications.Find(id);
            currentApplication.AppStatus = "UNAPPROVED";
            db.SaveChanges();
        }
        //Save Record and Redirect
        return RedirectToAction("Index");
    }
