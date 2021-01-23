    for (int r = 0; r < GridView1.Rows.Count; r++)
    {
        TextBox tb1 = (TextBox)GridView1.Rows[r].FindControl("TextBox2");
    
        TextBox tb2 = (TextBox)GridView1.Rows[r].FindControl("TextBox3");
    
    if(tb1.Text==null)
    {
    tb1.Enabled=false;
    }
    else
    {
    tb1.Enabled=true;
    }
    if(tb2.Text==null)
    {
    tb2.Enabled=false;
    }
    else
    {
    tb2.Enabled=true;
    }
    
    }
