     public ActionResult DownloadXLTMFile()
            {
                try
                {
                   //Using Resposne Stream to Make File Available for User to Download;
                    Response.Clear();
    
                    Response.ContentType = "application/vnd.ms-excel.template.macroEnabled.12";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}",  "YourFileName.xltm"));
    
                    Response.BinaryWrite(System.IO.File.ReadAllBytes(HostingEnvironment.MapPath("~/App_Data/YourManupulatedFile.xltm")));
                    Response.End();
                }
                catch (Exception Ex)
                {  }
                finally
                {}
                return View();
            }
