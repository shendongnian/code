    public Stream DownloadFile()
    {
        using (SqlConnection con = new SqlConnection("GAPDB"))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT FileUpload FROM [FirmWareVersion]", con))
            {
                con.Open();
    
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                     byte[] data = (byte[])reader["FileUpload"];
                     System.IO.MemoryStream ms = new System.IO.MemoryStream(data);
                     return ms;
                }
            }
        }
        return null;
    }
