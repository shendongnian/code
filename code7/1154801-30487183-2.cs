    [HttpPost]
        public ActionResult Create(StudentModel StudentEn,HttpPostedFileBase File1) 
                {
                    Student st = new Student();
                    //HttpPostedFileBase file;
        
                  // file = Request.Files["File1"];///it only access the name of the
                                    //object of html."file1" is the name of the object
        
                    if (File1 != null && File1.ContentLength > 0)
                    {
                        byte[] Image=null;
                        Image = new byte[File1.ContentLength];
                        File1.InputStream.Read(Image, 0, File1.ContentLength);
                       StudentEn.Image=Image;
                    }
                    if (ModelState.IsValid)
                    {
                        st.Insert(StudentEn);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        StudentEn.STDs = getSelectedSTD(GetSTDList());
                        return View(StudentEn);
                    }
                } 
    
