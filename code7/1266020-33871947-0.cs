    string newfilename = txtname.Text + "Resume" + fileExtension;
    string[] pathOfFiles =  System.IO.Directory.GetFiles(Server.MapPath("/tmp/jobres/" + uId));
    foreach (string filePath in pathOfFiles)
    {
        System.IO.File.Delete(filePath);
    }
    AsyncFileUpload1.SaveAs(Server.MapPath("/tmp/jobres/" + uId) + "\\" + newfilename;
