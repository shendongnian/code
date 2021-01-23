    [HttpPost]
        public ActionResult Create(Period collection)
        {
            string fpath = "";
            try
            {
                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpPostedFileBase file = collection.File;
                        string fname;
                        // want to check extension then use this method
                        //if (CheckExtension(file.ContentType.ToLower()))
                        //{
                            // Checking for Internet Explorer  
                            string extension = System.IO.Path.GetExtension(file.FileName);
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = Guid.NewGuid() + extension; //+ testfiles[testfiles.Length - 1];
                            }
                            else
                            {
                                fname = Guid.NewGuid() + extension; //+ file.FileName;
                            }
                            // Get the complete folder path and store the file inside it.  
                            fname = System.IO.Path.Combine(Server.MapPath("~/Content/"), fname);
                            file.SaveAs(fname);
                            
                            return Content("Successfully Uploaded");
                        //}
                    }
                    catch (Exception ex)
                    {
                        return Content("Error occurred. Error details: " + ex.Message);
                    }
                }
            }
            catch (Exception)
            {
                return Content(Response.StatusCode.ToString() + " Bad Requrest error." + fpath);
            }
            return Content("No files selected.");
        }
        public bool CheckExtension(string Ext)
        {
            if (Ext == "application/pdf")
            {
                return true;
            }
            else if (Ext == "text/plain")
            {
                return true;
            }
            else if (Ext == "application/msword")
            {
                return true;
            }
            else if (Ext == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
