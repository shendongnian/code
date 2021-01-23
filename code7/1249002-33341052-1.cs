    using(SqlConnection sqlcon = con.Sambung())
    using(SqlCommand com = sqlcon.CreateCommand())
    {
        com.CommandText = "select count (ID_Candidate) as Score from DataVote where ID_Candidate = @idcan";
        com.Parameters.Add("@idcan", SqlDbType.VarChar, 5).Value = score;
        sqlcon.Open();
        textBox4.Text = com.ExecuteScalar().ToString();
    }
