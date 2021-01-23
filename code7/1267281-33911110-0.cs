    [HttpPost]
            public JsonResult Index(HttpPostedFileBase[] files1, HttpPostedFileBase[] files2)
            {
                JsonResult result = new JsonResult();
    
                foreach (HttpPostedFileBase file in files1)
                {
                    /*Geting the file name*/
                    string filename = System.IO.Path.GetFileName(file.FileName);
                    /*Saving the file in server folder*/
                    file.SaveAs(Server.MapPath("~/Images/" + filename));
                    string filepathtosave = "Images/" + filename;
                    /*HERE WILL BE YOUR CODE TO SAVE THE FILE DETAIL IN DATA BASE*/
                }
    
                return result;
            }
