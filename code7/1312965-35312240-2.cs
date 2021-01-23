    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label Salary = (Label)e.Row.FindControl("lblSalary");        
        m = m + int.Parse(Salary.Text);
        //Table tb = new Table();
      }
 
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalPrice = (Label)e.Row.FindControl("Salary");
        lblTotalPrice.Text = m.ToString();
      }
    }
