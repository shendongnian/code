    protected void products_ItemDataBound1(object sender, ListViewItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                string productID = DataBinder.Eval(e.Item.DataItem, "ColumnNameWithID").ToString();
                string query = "SELECT stock_status FROM products WHERE ID = '" + productID + "'";
                DataTable dt = this.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    ((Label)e.Item.FindControl("checkReadyStock")).Text = dt.Rows[0][2].ToString();
                    if (((Label)e.Item.FindControl("checkReadyStock")).Text == "Ready Stock")
                    {
                        ((Image)e.Item.FindControl("readyStock")).Visible = true;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex);
        }
    }
