    protected void Buton1_Click(object sender, EventArgs e)
    {
      DataTable dt =null;
     if(Session["GridData"]==null)//Initialize a new session only if first time
     {
        dt= new DataTable();
        DataColumn dc = new DataColumn("Name");
        dt.Columns.Add(dc);
     }
     else 
     {
        dt=Session["GridData"] as DataTable;
     }
     
      DataRow dr = dt.NewRow();
      dr["Name"] = TextBox1.Text;
      dt.Rows.Add(dr);
      dt.AcceptChanges();
      GridView1.DataSource = dt;
      GridView1.DataBind();
      Session["GridData"]=dt;//save data in session to retrive in next click
    }
