    using(var con = new SqlConnection(conString))
    using(var cmd = con.CreateCommand())
    {
        cmd.CommandText = @"insert into tblnewaccount
                            values (@id, @date)";
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = dateTimePicker1.Value;
        con.Open();
        cmd.ExecuteNonQuery();
    }
