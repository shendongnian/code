    var imgCmd = new OracleCommand("SELECT photo FROM photos WHERE photo_id = 1", _con);
    imgCmd.InitialLONGFetchSize = -1; // Retrieve the entire image during select instead of possible two round trips to DB
    var reader = imgCmd.ExecuteReader();
    if (reader.Read()) {
        // Fetch the LONG RAW
        OracleBinary imgBinary = reader.GetOracleBinary(0);
        // Get the bytes from the binary obj
        byte[] imgBytes = imgBinary.IsNull ? null : imgBinary.Value;
    }
    reader.Close();
