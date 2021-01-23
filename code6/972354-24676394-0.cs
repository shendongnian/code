    public void UploadFile()
    {
        var file      = FileUpload1.PostedFile;
        var title     = TextBox1.Text;
        var text      = TextBox2.Text;
        var id_writer = Session["is_login"];
        var filename  = string.Empty;
        
        if (TryUploadFile(file, out filename))
        {
            if (!TryInsertFile(title, text, id_writer, filename))
            {
                File.Delete(filename);
            }
        }
    }
