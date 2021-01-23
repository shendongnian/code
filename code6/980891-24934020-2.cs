    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
          if(GroupIdentifyCondition)//your rule for identify a group
          {
               e.Row.CssClass += " tr.normal";            
          }
    	  else{
    			e.Row.CssClass += " tr.alternate";            
    	  }
      }
    }
