    static byte[] ReadFile(string filename)
    {	
         SqlConnection conn= new SqlConnection("Server=(localdb)\\v11.0 ; Initial Catalog = {your db name}; Integrated Security = SSPI");
    
        SqlCommand cmd = new SqlCommand("SELECT * FROM FileTable1 WHERE filePath=@filePath", conn);
    
        cmd.Parameters.AddWithValue("@filePath", filename);
        conn.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        rdr.Read();
        MemoryStream ms = new MemoryStream();
    
        long startIndex= 0;
        const int readSize= 256;
        while (true)
        {
            byte[] buffer = new byte[readSize];
            long bytesRead= rdr.GetBytes(1, startIndex, buffer, 0, readSize);
            ms.Write(buffer, 0, (int)bytesRead);
            startIndex += bytesRead;
            if (bytesRead != readSize) break;
        }
        conn.Close();
        byte[] byteArr = ms.ToArray();
        ms.Dispose();
    
        return byteArr;
    }
