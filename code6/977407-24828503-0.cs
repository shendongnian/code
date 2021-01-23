    public ActionResult LogOn(LogOnModel model, string returnUrl)
    {
        SqlConnection conn = null;
        conn = new SqlConnection("Server=(local);Database=holidaydatabase;User Id=holidaylogin;Password=test");
        SqlCommand command = new SqlCommand("EmployeeValidation", conn);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Username", SqlDbType.VarChar).Value = model.UserName;
        command.Parameters.Add("@Password", SqlDbType.VarBinary).Value =model.Password;
		
		DataSet ds = new DataSet();
		SqlDataAdapter dataadapter = new SqlDataAdapter(command, conn);
		dataadapter.Fill(ds);
		
		ds.Tables(0).Rows.Count //to know if the query returned values. 
		ds.Tables(1).Rows.Count 
		ds.Tables(2).Rows.Count
		
    }
