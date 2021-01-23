    SqlConnection conn = new SqlConnection(connectionString);
    
    try
    {
        int imageLength = uploadInput.PostedFile.ContentLength;
        byte[] picbyte = new byte[imageLength];
        uploadInput.PostedFile.InputStream.Read (picbyte, 0, imageLength);
    
        SqlCommand command = new SqlCommand("INSERT INTO ImageTable (ImageFile) VALUES (@Image)", conn);
        command.Parameters.Add("@Image", SqlDbType.Image);
        command.Parameters[0].Value = picbyte;
    
        conn.Open();
        command.ExecuteNonQuery();
        conn.Close();
    }
    finally
    {
        if (conn.State != ConnectionState.Closed)
        {
            conn.Close();
        }
    }
