    string w = ConfigurationManager.ConnectionStrings["LMS"].ConnectionString;
    using (SqlConnection conn = new SqlConnection(w))
    {
        DataTable dt = new DataTable();
        using (SqlCommand cmd = new SqlCommand("inserttwo", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = BookID;
            cmd.Parameters.Add("@BookName", SqlDbType.NVarChar, 50).Value = BookName;
            cmd.Parameters.Add("@DateIssue", SqlDbType.DateTime).Value = Date;
            cmd.Parameters.Add("@ReturnDate", SqlDbType.DateTime).Value = ReturnDate;
            cmd.Parameters.Add("@PersonID", SqlDbType.Int).Value = PersonID;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            conn.Open();
            sda.Fill(dt);
            metroGrid1.DataSource = dt;
        }
        conn.Close();
    }
