    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {    
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          TextBox tb1= (TextBox)e.Row.FindControl("TextBox2");
        
        if(String.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "now"))))
             tb1.Enabled = false; 
    
          TextBox tb2= (TextBox)e.Row.FindControl("TextBox3");
          if(String.IsNullOrEmpty(Convert.ToString(DataBinder.Eval(e.Row.DataItem, "afteronehour"))))
             tb2.Enabled = false; 
       }
    }
