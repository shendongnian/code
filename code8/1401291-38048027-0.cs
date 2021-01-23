    protected void gvNews_Sorted(object sender, GridViewSortEventArgs e)
    {
       List<News>result = (List<News>)ViewState["dt"];
       if (result.Count>0)
       {
          if(ViewState["sort"].ToString()=="Asc")
          {
            result = result.OrderBy(e.SortExpression + " Desc").ToList();
            ViewState["sort"] = "Desc";
          }
          else
          {
             result = result.OrderBy(e.SortExpression + " Asc").ToList();
             ViewState["sort"] = "Asc";
          }
          gvNews.DataSource = result;
          gvNews.DataBind();
       }
    }
