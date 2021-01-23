    public HttpPostedFileBase EditSlider(HttpPostedFileBase file)
    {
        if (file != null)
        {
            var pic = Path.GetFileName(file.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/images/slider"), pic);
            file.SaveAs(path);
        }
        return file;
    }
