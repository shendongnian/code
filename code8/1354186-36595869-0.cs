    protected void gvOrderItems_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
      gvOrderItems.PageIndex = e.NewPageIndex;
      if (Session["SortedView"] != null)
      {
        gvOrderItems.DataSource = Session["SortedView"];
        gvOrderItems.DataBind();
      }
      else
      {
        PopulateOrderList();
      }      
    }
