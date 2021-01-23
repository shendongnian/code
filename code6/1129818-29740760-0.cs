     protected void grdUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = Session["tbl_user"] as DataTable;
        if (dt != null)
        {
            //Sort the data.
            dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            grdUser.DataSource = Session["tbl_user"];
            grdUser.DataBind();
        }
    }
