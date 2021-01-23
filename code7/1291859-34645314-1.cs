    SqlConnection con = new SqlConnection(connectionString);
    SqlCommand cmd = new SqlCommand("select identifier, value from table_name", con);
    
    try{
        con.Open();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        rptTable.DataSource = ds;
        rptTable.DataBind();
    }
    catch(Exception ex){
        //...
    }
    finally{
        con.Close();
    }
