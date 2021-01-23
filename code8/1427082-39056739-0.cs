    [HttpPost]
     public ActionResult PostAVideo(PostVideo model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file.ContentLength > 0)
            {
                string filePath = "/Uploads/" + WebSecurity.CurrentUserName + "/" + model.Category;
                if (!Directory.Exists(Server.MapPath(filePath)))
                {
                    Directory.CreateDirectory(Server.MapPath(filePath));
                }
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(filePath), fileName);
                file.SaveAs(path);
                Video _model = new Video();
                _model.Title = model.Title;
                _model.Path = filePath + "/" + fileName;
                _model.Keyword = model.Keyword;
                _model.Description = model.Description;
                _model.Categories = model.Category;
                _model.CreatedDate = model.CreatedDate;
                _model.UserName = User.Identity.Name;
                _model.UserId = WebSecurity.CurrentUserId;
                _model.Name = fileName;
                _model.IsDownload = model.IsDownload;
                _model.IsCommented = model.IsComment;
                _model.Poster = WebSecurity.CurrentUserName;
                db.Video.Add(_model);
                db.SaveChanges();
                ModelState.Clear();
            }
            
            return View();
        }
