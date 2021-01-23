    private void repSubsidiaryList_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
       Item item = (Item)e.Item;
       InnerRepeater = (Repeater) e.Item.FindControl("InnerRepeater");
       InnerRepeater.DataSource = item.Children;
       InnerRepeater.DataBind();
    }
