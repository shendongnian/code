        [ActionName("Index")]
        [HttpPost]
        public ActionResult IndexPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var result = Request.Form["result"];
            CurrentApplication currentApplication = db.CurrentApplications.Find(id);
            currentApplication.AppStatus = result;
            db.SaveChanges();
            //Save Record and Redirect
            return RedirectToAction("Index");
        }
