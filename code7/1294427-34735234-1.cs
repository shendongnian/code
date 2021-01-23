    public static bool StoreBlobImage(OracleConnection conn, string ArtNr, byte[] bImageJpg)
    {
        bool Ok = false;
        string Sql = "update MyTable set Image = :Image where ArtNr = :ArtNr";
        using (OracleCommand cmd = new OracleCommand(Sql, conn))
        {
            cmd.Parameters.Add("Image", OracleDbType.Blob).Value = bImageJpg;
            cmd.Parameters.Add("ArtNr", OracleDbType.Varchar2, 8).Value = ArtNr;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception TheException)
            {
            }
        }
        return Ok;
    }
