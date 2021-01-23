    protected void gvNews_Sorted(object sender, GridViewSortEventArgs e)
    {
       List<News>result = (List<News>)ViewState["dt"];
       if (result.Count>0)
       {
          if(ViewState["sort"].ToString()=="Asc")
          {
            if ("titNew" == e.SortExpression)
    			result = result.OrderByDescending(r => r.titNew).ToList();
    	    //...do it to all the fields
            
            ViewState["sort"] = "Desc";
          }
          else
          {
            if ("titNew" == e.SortExpression)
    			result = result.OrderBy(r => r.titNew).ToList();
    	    //...do it to all the fields
             ViewState["sort"] = "Asc";
          }
    
          gvNews.DataSource = result;
          gvNews.DataBind();
          ViewState["dt"] = result;
       }
    }
