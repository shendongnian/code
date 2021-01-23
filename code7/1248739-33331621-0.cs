      protected void rebindGVProducts()
      {
        string strError = "";
        int soID = 0;
        if(ViewState["SOID"] != null)
            soID = Convert.ToInt32(ViewState["SOID"]);
        //hSOId.Value = soID;
        try
        {
            //Get all Products in this sales order
            ConnectionStringSettings SHConn = ConfigurationManager.ConnectionStrings["Conn"];
            SqlConnection objConn = new SqlConnection(SHConn.ConnectionString);
            //SqlDataReader objRdr;
            SqlCommand objCmd;
            objConn.Open();
            objCmd = new SqlCommand("spSalesOrderProductsRead", objConn);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.AddWithValue("@SalesOrderID", soID);
            SqlDataAdapter adapter = new SqlDataAdapter(objCmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Products");
            gvProducts.DataSource = ds;
            gvProducts.DataSourceID = String.Empty;
            gvProducts.DataBind();
            //objRdr.Close();
            objConn.Close();
        }
        catch (SqlException objSqlDbException)
        {
            foreach (SqlError objError in objSqlDbException.Errors)
            {
                //Response.Write("Error is: "+objError);
                strError += objError;
            }
            //add errors to error log file ErrorLogFile.txt
            reportError(strError);
            Response.Write("Sorry - we are currenly experiencing problems with our database, please try again later.");
        }
    }
