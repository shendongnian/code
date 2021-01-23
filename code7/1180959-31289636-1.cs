    private static void Task()
    {
        String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            con.Open();
            DateTime Newdate;
            String ct = DateTime.Now.ToString("dd/MM/yyyy");
            DateTime CT = DateTime.ParseExact(ct, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            SqlCommand cmd1 = new SqlCommand("select Date from tblInsertDate", con);
            cmd1.ExecuteNonQuery();
            SqlDataReader rdr = cmd1.ExecuteReader();
           List<DateTime> dates=new List<DateTime();
            while (rdr.Read())
            {
                DateTime dt = DateTime.ParseExact(rdr["Date"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                int result = DateTime.Compare(dt, CT);
                if (result < 0)
                {
                    Newdate = dt.AddDays(7);
                    dates.Add(Newdate);
                   
                }
            }
            foreach(DateTime dt in dates)
            {
                    SqlCommand cmd2 = new SqlCommand("update tblInsertDate set Date=@Newdate", con);
                    cmd2.Parameters.AddWithValue("@Newdate", dt);
                    cmd2.ExecuteNonQuery();
            }
        }
    }
