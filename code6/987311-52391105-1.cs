        [HttpPost]
        public ActionResult Upload()
        {
            //var r = new List<ViewDataUploadFilesResult>();
            var r = new ViewDataUploadFilesResult();
            Assignment a = new Assignment();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        int fileSize = file.ContentLength;
                        var fileName = Path.GetFileName(file.FileName);
                        //You could do this to get the content -
                        //it would need a varbinary(max) field 
                        //Stream posted file into a byte array
                        byte[] fileByteArray = new byte[fileSize];
                        file.InputStream.Read(fileByteArray, 0, fileSize);
                        //Uploading properly formatted file to server.
                        string fileLocation = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                        if (!Directory.Exists(Server.MapPath("~/App_Data/uploads")))
                            Directory.CreateDirectory(Server.MapPath("~/App_Data/uploads"));
                        file.SaveAs(fileLocation);
                        
                        // I used a ViewModel to collect my file information
                        ViewDataUploadFilesResult r = new ViewDataUploadFilesResult();
                        r.Name = fileName;
                        r.FilePath = fileLocation;
                        r.Length = fileSize;
                        r.FileObj = file;
                        r.Content = fileByteArray;
                        // I provided a list so I could upload multiple files
                        // at once, but you might've just had the one item, above
                        //r.Add(new ViewDataUploadFilesResult()
                        //{
                        //    Name = fileName,
                        //    FilePath = fileLocation,
                        //    Length = fileSize,
                        //    FileObj = file,
                        //    Content = fileByteArray
                        //});
                        // Below is for singular ViewDataUploadFilesResult objects (uncomment the loop for multiple)
                        //for (int i = 0; i < r.Count; i++)
                        //{
                            //assignment.FileLocation = r[i].FilePath; //multiple objects need an index, [i]
                            assignment.FileLocation = r.FilePath;  //singular objects don't
                            assignment.Status = "Uploaded";
                            assignment.Comments = "Completed";
                        //}
                        // You also could've just not used ViewDataUploadFilesResult 
                        // at all, and just used assignment, only
                        // and just added fileSize, fileContents, etc. to it
                    }
                    EFModel db = new EFModel();  // this is your Entity Framework context
                    db.Assignments.Add(assignment);  //"Assignments" would be your table
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    //return View("Index", r);
                }
            }
            return View();
        }
