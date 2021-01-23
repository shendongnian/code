    private void BindStudents()
    {
	String strConnStr =  ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
	SqlConnection con =  new SqlConnection(strConnStr);
	SqlCommand cmd = new SqlCommand();
	cmd.CommandType = CommandType.StoredProcedure;
	cmd.CommandText = "sp_selectlendingstatus";
	cmd.Connection = con;
	try
    {
    	con.Open();
    	GridView1.EmptyDataText = "No Records Found";
    	GridView1.DataSource = cmd.ExecuteReader() ;
    	GridView1.DataBind(); 
    }
    catch (Exception ex)
    {
    	throw ex;
    }
    finally
    {
    	con.Close();
    	con.Dispose();
     }
    }
