    var imgCmd = new OracleCommand("SELECT photo FROM photos WHERE photo_id = 1", _con);
    var reader = imgCmd.ExecuteReader();
    if (reader.Read()) {
        // Fetch the blob
        OracleBlob imgBlob = reader.GetOracleBlob(0);
        // Create byte array to read the blob into
        byte[] imgBytes = new byte[blob.Length];
        // Read the blob into the byte array
        blob.Read(imgBytes, 0, blob.Length);
    }
    reader.Close();
