    public static string UploadFile(HttpPostedFileBase file)
            {
                if (file != null)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var rondom = Guid.NewGuid() + fileName;
                    var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/Files/"), rondom);
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/Content/Files/")))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Files/"));
                    }
                    file.SaveAs(path);
    
                    return rondom;
                }
                return "nofile.png";
            }
