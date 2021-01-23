    protected void b1_Click(object sender, EventArgs e)
    {
        //Use the global variable dt
        //DataTable dt = (DataTable)ViewState["dt"];       
        dt = (DataTable)ViewState["dt"];       
        ViewState["dt"] = AddRow(dt);
        radGridView2.Rebind();   //Note this would call the NeedDataSource event
        Session["cttt"] = Convert.ToInt32(sno.Text)+1;
        sno.Text = Session["cttt"].ToString(); 
    }
