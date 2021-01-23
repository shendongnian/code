    protected void RadGrid1_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if(e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            if(e.Item is GridEditFormItem)
            {
                GridEditFormItem item = (GridEditFormItem)e.Item;
                TextBox TextBox1 = (TextBox)item.FindControl("TextBox1");
                TextBox1.Text = item["column"].Text;
            }
        }
    }
