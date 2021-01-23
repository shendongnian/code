    private void RefreshBTN_Click(object sender, EventArgs e)
    {
        //call both functions to refresh both on button click
        RefreshGrid1();
        RefreshGrid2();
    }
    
    private void RefreshGrid1()
    {
        SqlConnection myConnection = new SqlConnection("removed for illustration only");
        string query = "select * from daily_orders order by orderno DESC";
        SqlCommand cmd = new SqlCommand(query, myConnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        dataGridView1.DataSource = dt;
    }
    
    //give this function a unique name to represent the second grid refresh
    private void RefreshGrid2()
    {
        SqlConnection myConnection = new SqlConnection("removed for illustration only");
        string query = "select * from daily_orders order by orderno DESC";
        SqlCommand cmd = new SqlCommand(query, myConnection);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        //rename this to your second grid name
        dataGridView2.DataSource = dt;
    }
