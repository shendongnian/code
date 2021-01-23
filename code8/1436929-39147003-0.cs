     public static void databaseFilePut(string imgLoc) {
        byte[] file;
        using (var stream = new FileStream(imgLoc, FileMode.Open, FileAccess.Read)) {
            using (var reader = new BinaryReader(stream)) {
                file = reader.ReadBytes((int) stream.Length);       
            }          
        }
        using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
        using (var sqlWrite = new SqlCommand("INSERT INTO Firma(Name, Logo)Values(@File)", varConnection)) {
            sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            sqlWrite.ExecuteNonQuery();
        }
    }
