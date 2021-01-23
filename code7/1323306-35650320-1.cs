    SqlCeConnection con = new SqlCeConnection(@"Data Source=...users.sdf");
    con.Open();
    using (SqlCeCommand comm = new SqlCeCommand("SELECT * FROM final_tests WHERE score LIKE @score", con))
    {
    comm.Parameters.Add(new SqlCeParameter("score", score));
    SsqlDataAdapter aa= new SsqlDataAdapter(Comm);
    DataTable dt= new Datatable();
    da.Fill(dt);
    }
