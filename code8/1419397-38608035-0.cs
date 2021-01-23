    private void vendordetails(string vendorName = "")
    {
        try
        {
            con.Open();
            query =  String.Format( "select * from vendor where vendor_name = \'{0}\'", vendorName);
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
    
            DataSet ds = new DataSet();
            da.Fill(ds);
    
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
