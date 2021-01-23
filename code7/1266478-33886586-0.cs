    double subtotal = 0;
    double price = 0;
    protected void rptItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            price += Convert.ToDouble(DataBinder.Eval(e.Item.DataItem, "Price"));
            subtotal += price;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblSubtotal = (Label)e.Item.FindControl("lblSubtotal");
            lblSubtotal.Text = subtotal.ToString();
        }
    }
