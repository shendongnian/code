     private void GridViewDataBind()
     {
        DataTable dt = GetDataTable();
        if (Session["sessionsort"] != null)
        {
            //Sort the data.
              dt.DefaultView.Sort = Session["sessionsort"].ToString();
        }
        gridview.DataSource = dt;
        gridview.DataBind();
    }
