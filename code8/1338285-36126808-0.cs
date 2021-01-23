    SelfCollectNameSpace.SelfCollect address = new SelfCollectNameSpace.SelfCollect();
    protected void MyGrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
          Label labelSelf = (Label)e.Row.FindControl("labelSelf");
          labelSelf.Text = address.getSelfCollectAddress(orderNoTracking); // maybe you need to retrieve the orderNoTracking from another control in this row or from it's datasource
      }
    }
