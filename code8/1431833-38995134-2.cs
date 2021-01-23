    using (strCon)
    {        
        foreach (var fund in fundList)
        {
            SqlCommand cmd = new SqlCommand("[dbo].[z_Formulas2]", strCon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            cmd.Parameters.Add(new SqlParameter("@Fund_ID", fund));
            cmd.Parameters.Add(new SqlParameter("@XFund_ID", ""));
            cmd.Parameters.Add(new SqlParameter("@Start_Dated", fromDate));
            cmd.Parameters.Add(new SqlParameter("End_Dated", toDate));
        
            sda.Fill(ds);
        }
    }
