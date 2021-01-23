    string Fileloc = "/" + "Content/Upload/YourFolder/";
    
    if (FileUpload1.PostedFile!=null)
                                    {
                                        if (System.IO.Directory.Exists(Fileloc))
                                        {
                                            var path = Path.Combine(HttpContext.Current.Server.MapPath(Fileloc), FileUpload1.PostedFile.FileName);
                                            FileUpload1.PostedFile.SaveAs(path);
                                        }
                                        else
                                        {
                                            System.IO.Directory.CreateDirectory(Fileloc);
                                            var path = Path.Combine(HttpContext.Current.Server.MapPath(Fileloc), FileUpload1.PostedFile.FileName);
                                            FileUpload1.PostedFile.SaveAs(path);
                                        }
