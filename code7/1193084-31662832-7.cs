    static void InsertFile(string filename)
    {	
        SqlConnection conn = new SqlConnection("Server=(localdb)\\v11.0 ; Initial Catalog = {your db name}; Integrated Security = SSPI");
    		
        SqlCommand cmd = new SqlCommand("INSERT INTO FileTable1 VALUES (@filePath, @data)", conn);
    
        cmd.Parameters.AddWithValue("@filePath", Path.GetFileName(filename));
        cmd.Parameters.Add("@data", SqlDbType.VarBinary, -1).Value = File.ReadAllBytes(filename);
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
