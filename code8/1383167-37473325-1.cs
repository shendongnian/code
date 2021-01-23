    using System.Data.SqlClient;
    using System.IO;
    
    byte[] data;
    using (FileStream fs = new FileStream(document, FileMode.Open)
    {
        BinaryReader fileReader = new BinaryReader(document);
        data = fileReader.ReadBytes((int)document.Length);
        document.Close(); // don't forget to close file stream
    }
    
    using (var connection = new SqlConnection("YourConnectionStringHere"))
    {
        connection.Open();
        using (var command = new SqlCommand("YourSPHere", connection)
        {
            command.CommandType = CommandType.StoredProcedure;
            // insert parameters here
            // add file parameter at the end of collection parameters
            command.Parameters.AddWithValue("@File", SqlDbType.VarBinary).Value = data;
            command.ExecuteNonQuery();
        }
        connection.Close();
    }
