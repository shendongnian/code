    {    
        DataTable dt = new DataTable();
        dt.Columns.Add("Name");
        dt.Columns.Add("Address");
        dt.Columns.Add("Contact");
        dt.Columns.Add("FromDate");
        dt.Columns.Add("ToDate");
        dt.Columns.Add("Website");
    
        DataRow dr1 = dt.NewRow();
    
        dr1["Name"] = TextBox1.Text;
        dr1["Address"] = TextBox2.Text;
        dr1["Contact"] = TextBox3.Text;
        dr1["FromDate"] = FromDate.Text;
        dr1["ToDate"] = ToDate.Text;
        dr1["Website"] = TextBox6.Text;
    
        dt.Rows.Add(dr1);
        GridView1.DataSource = dt;  
        GridView1.DataBind(); 
    }
