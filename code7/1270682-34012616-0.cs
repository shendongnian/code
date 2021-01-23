    string filePath = FileUpload1.PostedFile.FileName;  
    string filename = Path.GetFileName(filePath);
    string ext = Path.GetExtension(filename);
    string contenttype = String.Empty;
     switch(ext)
    {
        case ".doc":
            contenttype = "application/vnd.ms-word";
            break;
        case ".docx":
            contenttype = "application/vnd.ms-word";
            break;
    }
     if (contenttype != String.Empty)
    {
 
        Stream fs = FileUpload1.PostedFile.InputStream;
        BinaryReader br = new BinaryReader(fs);
        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
 
        //insert the file into database
        string strQuery = "insert into tblFiles(Name, ContentType, Data)" +
           " values (@Name, @ContentType, @Data)";
        SqlCommand cmd = new SqlCommand(strQuery);
        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
        cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value
          = contenttype;
        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
        InsertUpdateData(cmd);
        lblMessage.ForeColor = System.Drawing.Color.Green;  
        lblMessage.Text = "File Uploaded Successfully";
    }
