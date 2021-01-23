      protected void Button1_Click(object sender, EventArgs e)
      {
     
       DataTable dt = new DataTable();
       if (dt.Columns.Count == 0)
       {
           dt.Columns.Add("nameofcolumn1", typeof(string));
           dt.Columns.Add("nameofcolumn2", typeof(string));
           dt.Columns.Add("nameofcolumn3", typeof(string));
       }
       DataRow NewRow = dt.NewRow();
       NewRow[0] = value1;
       NewRow[ 1] = value2;
       dt.Rows.Add(NewRow); 
       GridView1.DataSource = dt;
       GridViewl.DataBind();
    
       }
