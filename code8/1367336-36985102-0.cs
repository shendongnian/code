      protected void TaskGridView_Sorting(object sender, GridViewSortEventArgs e)
      {
    
        //Retrieve the table from the session object.
        DataTable dt = Session["TaskTable"] as DataTable;
    
        if (dt != null)
        {
    
          //Sort the data.
          dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
          TaskGridView.DataSource = Session["TaskTable"];
          TaskGridView.DataBind();
        }
    
      }
    
      private string GetSortDirection(string column)
      {
    
        // By default, set the sort direction to ascending.
        string sortDirection = "ASC";
    
        // Retrieve the last column that was sorted.
        string sortExpression = ViewState["SortExpression"] as string;
    
        if (sortExpression != null)
        {
          // Check if the same column is being sorted.
          // Otherwise, the default value can be returned.
          if (sortExpression == column)
          {
            string lastDirection = ViewState["SortDirection"] as string;
            if ((lastDirection != null) && (lastDirection == "ASC"))
            {
              sortDirection = "DESC";
            }
          }
        }
    
        // Save new values in ViewState.
        ViewState["SortDirection"] = sortDirection;
        ViewState["SortExpression"] = column;
    
        return sortDirection;
      }
