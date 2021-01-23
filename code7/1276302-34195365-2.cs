    public ActionResult Product_Delete()
    {
        string idnumber = "07";
        string mappedPath = Server.MapPath(@"~/Content/Essential_Folder/attachments_AR/" + idnumber);
        Directory.Delete(mappedPath, true);
    } 
