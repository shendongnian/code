    stringConnectionString = ("Data Source=192.161.0.0;Initial Catalog=kkh_final;Persist Security Info=True;User ID=xx;Password=yyyyyyy");
    DataSet objDataSet = new DataSet();
    using (SqlConnection connection = new SqlConnection(stringConnectionString))
    {
        SqlCommand cmd = new SqlCommand("dbo.MyProcedure", connection);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter pdParam = new SqlParameter("@YourParam", SqlDbType.VarChar);
        pdParam.Value = pd;
        cmd.Parameters.Add(pdParam);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        try
        {
            da.Fill(objDataSet);
        }
        catch (Exception ex) 
        {
            string error = ex.Message;
        }
    }
