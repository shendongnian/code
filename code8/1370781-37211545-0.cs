     public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
    
                Project project = db.Projects.Find(id);
                var user = UserManager.FindByIdAsync(project.UserId);
                ViewData["user"] = user.Result.Email;
    
               if (project == null)
                {
                    return HttpNotFound();
                }
                return View(project);
            }
