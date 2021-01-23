    string SurDateNext = "21/12/15 11:45 AM";
    string sql = "UPDATE [Dates] SET DateNow= @DateNext WHERE ID= @ID ;";
    using (var cn = new SqlConnection("connection string here"))
    using (var cmd = new SqlCommand(sql, cn))
    {
        cmd.Parameters.Add("@DateNext", SqlDbType.DateTime).Value = DateTime.ParseExact(SurDateNext, "dd/MM/yy hh:mm tt", CultureInfo.InvariantCulture);
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 135;
        cn.Open();
        cmd.ExecuteNonQuery();
    }
