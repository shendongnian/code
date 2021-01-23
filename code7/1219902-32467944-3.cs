    protected void btnUpdateData_Click(object sender, EventArgs e)
    {
        String startDate = jQueryUICalendar1.text; 
        String endDate = jQueryUICalendar2.text;
        DataSet ds = getData(startDate, endDate);
        if(ds != null and ds.tables.count > 0){
            bindGrid(ds.Tables[0]);
        }
    }
    Private DataSet getData(string sDate, string eDate){
        DataSet ds = default(DataSet);
        SqlConnection cnx = new SqlConnection("ConnectionString");
        String query = "SELECT stamp as 'Date', order_No as 'Order #', places.label as 'Location' FROM order_info, places WHERE originating_places_id = '123' and places.label = 'Detroit, MI' and stamp between '@sDate' and '@eDate'";
       SqlCommand cmd = new SqlCommand(query, cnx);
       cmd.CommandType = CommandType.Text;
       cmd.Parameters.AddWithValue("@sDate", sDate);
       cmd.Parameters.AddWithValue("@eDate", eDate);
       sqlDataAdapter da = New SqlDataAdapter(cmd);
       try{
            cnx.Open();
            da.Fill(ds);
            cnx.Close();            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);
        }
        finally
        {
            if (cnx != null) cnx.Close();
        }
        return ds;
    }
    private void bindGrid(DataTable dt){
        gridView.DataSource = ds.Tables[0];
        gridView.DataBind();
    }
