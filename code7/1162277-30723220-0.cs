    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.ContentType = "APPLICATION/OCTET-STREAM";
        String Header = "Attachment; Filename=x.7z";
        Response.AppendHeader("Content-Disposition", Header);
        System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath("~/x.7z"));
        Response.WriteFile(Dfile.FullName);
        //Don't forget to add the following line
        Response.End();
    
    }
