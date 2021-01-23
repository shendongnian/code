     Stream fs = FileUpload1.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);
     
            //insert the file into database
            string strQuery = "insert into Table_Name(FileName, Content_Type, ImageData)" +
               " values (@Name, @ContentType, @Data)";
            SqlCommand cmd = new SqlCommand(strQuery);
            cmd.Parameters.Add("@FileName", SqlDbType.VarChar).Value = filename;
            cmd.Parameters.Add("@Content_Type", SqlDbType.VarChar).Value
              = contenttype;
            cmd.Parameters.Add("@ImageData", SqlDbType.Binary).Value = bytes;
    cmd.ExecuteNonQuery();
