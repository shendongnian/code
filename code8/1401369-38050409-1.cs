    DataTable dt;
    protected void Save_Info(object sender, EventArgs e)
      {
        DataRow dr1 = dt.NewRow();
     
        dr1["Name"] =TextBox1.Text;
        dr1["Address"] =TextBox2.Text;
        dr1["Contact"] =TextBox3.Text;
        dr1["FromDate"] =FromDate.Text;
        dr1["ToDate"] =ToDate.Text;
        dr1["Website"] =TextBox6.Text;
        dt.Rows.Add(dr1); 
        GridView1.DataSource = dt;  //Gridview
        GridView1.DataBind(); //binding data to Gridview
     }
