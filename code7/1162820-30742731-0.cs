    DateTime timestamp;
    protected void OnDataBinding(object sender, EventArgs e)
    {
       timestamp = DateTime.Now ;
    }
    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DateTime Kbl = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "HrsKbl"));
        e.Row.BackColor = (Kbl == timestamp ? Color.Yellow : 
                          (Kbl > timestamp ? Color.Green : Color:Red));
      }
    }
