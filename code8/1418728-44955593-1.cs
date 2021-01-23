         public ActionResult DownloadXLTMFile()
                {
                    try
                    {
                      //Get your macro enabled file after manipulation
                       MemoryStream excelMS =  .....
                       //Using Resposne Stream to Make File Available for User to Download;
                        Response.Clear();
        
                        Response.ContentType = "application/vnd.ms-excel.template.macroEnabled.12";
                        Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}",  "YourFileName.xltm"));
        
                        Response.BinaryWrite(excelMS.ToArray());
                        Response.End();
                    }
                    catch (Exception Ex)
                    {  }
                    finally
                    {}
                    return View();
                }
