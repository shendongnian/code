        public void loadReport()
        {
            rd.Load(@"C:\Users\Jeff Enad\Desktop\TEST1\Cebu Hallmark Hotel Management System\Cebu Hallmark Hotel Management System\cryReport.rpt");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=dbCebuHallmark;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("GetAllReport", con);
            //rd.SetParameterValue("UserPrinted", user); //This is the parameter
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@UserPrinted", user);
            DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "REPORT");
            rd.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rd;
            crystalReportViewer1.Refresh();
        }
