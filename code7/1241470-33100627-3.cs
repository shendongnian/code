      try
      {
    
         if (ModelState.IsValid)
         {
               var fileName = Path.GetFileName(model.TeamPicture.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                    model.TeamPicture.SaveAs(path);
    
    
               team objTeam = new team
               {
                   teamName = model.TeamName,
                   teamPicture = path,
                   description = model.Description,
                   content = model.Content
               };
               objBs.teamBs.Insert(objTeam);
               TempData["Msg"] = "Created Successfully!";                    
               return RedirectToAction("Index");
           }
            
           //the view model is NOT valid
           return View(model)
                      
       }
       catch (DbEntityValidationException dbEx)
       {
           var sb = new StringBuilder();
           foreach (var validationErrors in dbEx.EntityValidationErrors)
           {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    sb.AppendLine(string.Format("Entity:'{0}' Property: '{1}' Error: '{2}'",
                                  validationErrors.Entry.Entity.GetType().FullName,
                                  validationError.PropertyName,
                                  validationError.ErrorMessage));
                 }
           }
                      //throw new Exception(string.Format("Failed saving data: '{0}'", sb.ToString()), dbEx);
                TempData["Msg"] = sb.ToString();
                return RedirectToAction("Index");
        }
