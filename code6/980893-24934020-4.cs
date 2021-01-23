    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
    		e.Row.CssClass += GroupColorRule(e.Row.DataItem as Object); // Object is your class type
      }
    }
    
    //Rule to alternate the colors by Date.
    private string CssGroupColorRule(Object entity){
    	
    	if(ViewState["LastDate"] == null){
    		ViewState["LastDate"] = entity.Date;
    		return " tr.normal";
    	}else{
    		if(entity.Date == Convert.ToDateTime(ViewState["LastDate"].toString()){
    			return " tr.normal";
    		}else{
    			ViewState["LastDate"] = entity.Date;
    			return " tr.alternate";
    		}
    	}
    }
