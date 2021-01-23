    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {    
         TextBox tb1= (TextBox)e.Row.FindControl("TextBox2");
         if(tb1.Text == string.Empty)
             tb1.Enabled = false; 
    
         TextBox tb2= (TextBox)e.Row.FindControl("TextBox3");
         if(tb2.Text == string.Empty)
             tb2.Enabled = false; 
    }
