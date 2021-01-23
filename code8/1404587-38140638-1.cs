    public ActionResult Upload(HttpPostedFileBase file)
    {
        string filename = Server.MapPath("~/CSV/" + file.FileName);
        file.SaveAs(filename);
        FileInfo fi = new FileInfo(filename);
        VirusTotal vtObj = new VirusTotal("%API KEY%");
        ScanResults result = vtObj.ScanFile(fi);
        .. ??? what to do if this is a virus ????
        ViewBag.Path = filename;
        return View();
    }
