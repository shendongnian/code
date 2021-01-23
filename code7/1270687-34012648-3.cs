            // Read the file and convert it to Byte Array
            string filePath = FileUpload1.PostedFile.FileName;  
            string filename = Path.GetFileName(filePath);
            Stream fs = FileUpload1.PostedFile.InputStream;
    
            BinaryReader br = new BinaryReader(fs);
    
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
    
     
    
            //insert the file into database
    
            string strQuery = "insert into tblFiles(Name, Data)" +
    
               " values (@Name, @Data)";
    
            SqlCommand cmd = new SqlCommand(strQuery);
    
            cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = filename;
    
           
    
            cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = bytes;
    
            InsertUpdateData(cmd);
    
            lblMessage.ForeColor = System.Drawing.Color.Green;  
    
            lblMessage.Text = "File Uploaded Successfully";
