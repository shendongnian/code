        protected void jobGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.FindControl("TitleLink") as LinkButton).OnClientClick = "javascript:return RedirectPage();";
            }
        }
