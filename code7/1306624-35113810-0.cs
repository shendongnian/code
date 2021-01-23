    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = e.Row.FindControl("Image1") as Image;
                string url = img.ImageUrl;
                string modified = url + "?time=" + DateTime.Now.ToString();
                img.ImageUrl = modified;
            }
        }
