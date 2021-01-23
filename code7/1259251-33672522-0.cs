    con.Open();
    if (Image.HasFile) {
        string filename = Path.GetFileName(Image.PostedFile.FileName);
        String ext = System.IO.Path.GetExtension(Image.FileName);
        string filesize = Image.FileBytes.Length.ToString();
        string qry1;
        string dir;
        if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif") {
            dir = "Posts/";
            qry1 = "insert into Images(Image_Name, Image_Size, Image_Path) values (@fn, @fs, @fp)";
            
        } else if (ext.ToLower() == ".mp4" || ext.ToLower() == ".mpeg" || ext.ToLower() == ".avi") {
            dir = "Posts/videos/";
            qry1 = "insert into videos(Video_Name, Video_Size, Video_Path) values (@fn, @fs, @fp)";
        }
        string filepath = Server.MapPath("~/" + dir + filename);
        Image.SaveAs(filepath);
        SqlCommand cmmd = new SqlCommand(qry1, con);
        cmmd.Parameters.AddWithValue("fn", filename);
        cmmd.Parameters.AddWithValue("fs", filesize);
        cmmd.Parameters.AddWithValue("fp", filepath);
        cmmd.ExecuteNonQuery();
    }
