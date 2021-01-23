    // Assuming "conn" is an open SqlConnection
    using(SqlCommand cmd = new SqlCommand("INSERT INTO TableImg(Image) VALUES (@binaryValue)", conn))
    {
        // Replace 8000, below, with the correct size of the field
        cmd.Parameters.Add("@binaryValue", SqlDbType.VarBinary, 8000).Value = arraytoinsert;
        cmd.ExecuteNonQuery();
    }
