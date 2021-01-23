    public System.IO.StreamWriter w = new System.IO.StreamWriter("Hierarchy.txt", false);
    string intend = "     ";
    private void getHierarchy(Google.Apis.Drive.v2.Data.File Res, DriveService driveService)
    {
        if (Res.MimeType == "application/vnd.google-apps.folder")
        {
            w.Write(intend + Res.Title + " :" + Environment.NewLine);
            intend += "     ";
            foreach (var res in ResFromFolder(driveService, Res.Id).ToList())
                getHierarchy(res, driveService);
            intend = intend.Remove(intend.Length - 5);
        }
        else
        {
            w.Write(intend + Res.Title + Environment.NewLine);
        }
    }
