    public ActionResult Product_Delete()
    {
        string idnumber = "07";
        string mappedPath1 = Server.MapPath(@"~/Content/Essential_Folder/attachments_AR/" + idnumber);
        DirectoryInfo attachments_AR = new DirectoryInfo(mappedPath1));
        EmptyFolder(attachments_AR);
        Directory.Delete(mappedPath1);
        ....
    } 
