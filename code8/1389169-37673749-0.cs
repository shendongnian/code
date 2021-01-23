    public bool loginpro(string loginas, string dept, string usnm, string pass)
    {
        try
        {
            string qrstr;
            qrstr = @"select * from login where loginas=@login and dept = @dept
                     and usnm = @user and pass= @pass";
            Gencon.Open();
            SqlCommand cmd = new SqlCommand(qrstr, Gencon);
            cmd.Parameters.Add("@login", SqlDbType.NVarChar).Value = loginas;
            cmd.Parameters.Add("@dept", SqlDbType.NVarChar).Value = dept;
            cmd.Parameters.Add("@user", SqlDbType.NVarChar).Value = usnm;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Gencon.Close();
            return (dt.Rows.Count > 0);
        }
        catch (Exception e)
        {
            Gencon.Close();
            return false;
        }
    }
