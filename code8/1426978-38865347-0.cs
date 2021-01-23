    SqlConnection con = new SqlConnection(.....);
    DataTable dt = new DataTable();
    try
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = "Select * from View_VisitorsForm where VisitingDate >= @fromDate and VisitingDate <= @toDate";
        command.Parameters.Add("@fromDate", System.Data.SqlDbType.Date).Value = VisitorsVM.FromDate;
        command.Parameters.Add("@toDate", System.Data.SqlDbType.Date).Value = VisitorsVM.ToDate;
        command.Connection = con;
        // con.Open();
        SqlDataAdapter adp = new SqlDataAdapter(command); 
        adp.Fill(dt);
    }
