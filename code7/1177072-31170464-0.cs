       [HttpPost]
        public ActionResult SaveFile(YourModel model)
        {
            foreach (string file in Request.Files)
            {
               SaveYourFile(Request.Files[file]);
            }
        return View();
        } 
         private void SaveYourFile(HttpPostedFileBase file)
         {
           if(file.ContentLenght >0)
             {
               //now you can access to your uploaded file
              var book = new books();
            var path = Path.Combine(Server.MapPath("~/Osho_Images"), file.fileName);
             book.File.SaveAs(path);
              booksBusinessLayer.AddBooks(_books);
             }
         }
