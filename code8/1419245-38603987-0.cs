    SqlParameter sParam = new SqlParameter("@image_byte_array", SqlDbType.VarBinary)
    {
     Value = image
    };
    SqlHelper.ExecuteNonQuery(Transaction, CommandType.Text, sql_insert_string, sParam)
